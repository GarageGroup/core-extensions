using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<Unit, TFailure> ForwardParallel<TIn, TFailure>(
        this AsyncPipeline<FlatArray<TIn>, TFailure> pipeline,
        Func<TIn, CancellationToken, Task<Result<Unit, TFailure>>> forwardAsync,
        [AllowNull] PipelineParallelOption option = default)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(forwardAsync);
        var continueOnCapturedContext = pipeline.Configuration.ContinueOnCapturedContext;

        if (option?.FailureAction is not PipelineParallelFailureAction.Stop)
        {
            return pipeline.MapSuccessValue(InnerForwardAsync).Forward(InnerJoinSuccess<TIn, TFailure>);
        }

        return pipeline.ForwardValue(InnerPipeCatchingAsync);

        ValueTask<FlatArray<Result<Unit, TFailure>>> InnerForwardAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(forwardAsync, option, pipeline.Configuration, cancellationToken);

        async ValueTask<Result<Unit, TFailure>> InnerPipeCatchingAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
        {
            if (input.Length < 2)
            {
                var results = await InnerForwardAsync(input, cancellationToken).ConfigureAwait(continueOnCapturedContext);
                return InnerJoinSuccess<TIn, TFailure>(results);
            }

            try
            {
                return await input.InnerPipeParallelValueAsync(
                    InnerPipeOrExceptionAsync, option, pipeline.Configuration, cancellationToken).ConfigureAwait(continueOnCapturedContext);
            }
            catch (InnerFailureException<TFailure> ex)
            {
                return ex.Failure;
            }
        }

        async ValueTask<Unit> InnerPipeOrExceptionAsync(TIn input, CancellationToken cancellationToken)
        {
            var result = await forwardAsync.Invoke(input, cancellationToken).ConfigureAwait(continueOnCapturedContext);
            return result.SuccessOrThrow(InnerFailureException<TFailure>.From);
        }
    }
}