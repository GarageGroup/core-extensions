using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<FlatArray<TOut>, TFailure> ForwardParallel<TIn, TOut, TFailure>(
        this AsyncPipeline<FlatArray<TIn>, TFailure> pipeline,
        Func<TIn, CancellationToken, Task<Result<TOut, TFailure>>> forwardAsync,
        [AllowNull] PipelineParallelOption option = default)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(forwardAsync);
        var continueOnCapturedContext = pipeline.Configuration.ContinueOnCapturedContext;

        if (option?.FailureAction is not PipelineParallelFailureAction.Stop)
        {
            return pipeline.MapSuccessValue(InnerForwardAsync).Forward(InnerJoinSuccess<TIn, TOut, TFailure>);
        }

        return pipeline.ForwardValue(InnerPipeCatchingAsync);

        ValueTask<FlatArray<Result<TOut, TFailure>>> InnerForwardAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(forwardAsync, option, pipeline.Configuration, cancellationToken);

        async ValueTask<Result<FlatArray<TOut>, TFailure>> InnerPipeCatchingAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
        {
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

        async ValueTask<TOut> InnerPipeOrExceptionAsync(TIn input, CancellationToken cancellationToken)
        {
            var result = await forwardAsync.Invoke(input, cancellationToken).ConfigureAwait(continueOnCapturedContext);
            return result.SuccessOrThrow(InnerFailureException<TFailure>.From);
        }
    }
}