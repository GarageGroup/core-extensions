using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<FlatArray<TOut>, TFailure> PipeParallelValue<TIn, TOut, TFailure>(
        this AsyncPipeline<FlatArray<TIn>> pipeline,
        Func<TIn, CancellationToken, ValueTask<Result<TOut, TFailure>>> pipeAsync,
        [AllowNull] PipelineParallelOption option = default)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(pipeAsync);
        var continueOnCapturedContext = pipeline.Configuration.ContinueOnCapturedContext;

        if (option?.FailureAction is not PipelineParallelFailureAction.Stop)
        {
            return pipeline.PipeValue(InnerPipeAsync).Pipe(InnerJoinSuccess<TIn, TOut, TFailure>);
        }

        return pipeline.PipeValue(InnerPipeCatchingAsync);

        ValueTask<FlatArray<Result<TOut, TFailure>>> InnerPipeAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelValueAsync(pipeAsync, option, pipeline.Configuration, cancellationToken);

        async ValueTask<Result<FlatArray<TOut>, TFailure>> InnerPipeCatchingAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
        {
            if (input.Length < 2)
            {
                var results = await InnerPipeAsync(input, cancellationToken).ConfigureAwait(continueOnCapturedContext);
                return InnerJoinSuccess<TIn, TOut, TFailure>(results);
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

        async ValueTask<TOut> InnerPipeOrExceptionAsync(TIn input, CancellationToken cancellationToken)
        {
            var result = await pipeAsync.Invoke(input, cancellationToken).ConfigureAwait(continueOnCapturedContext);
            return result.SuccessOrThrow(InnerFailureException<TFailure>.From);
        }
    }
}