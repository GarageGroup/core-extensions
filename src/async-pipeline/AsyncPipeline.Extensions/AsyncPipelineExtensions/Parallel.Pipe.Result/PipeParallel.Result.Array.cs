using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<FlatArray<TOut>, TFailure> PipeParallel<TIn, TOut, TFailure>(
        this AsyncPipeline<FlatArray<TIn>> pipeline,
        Func<TIn, CancellationToken, Task<Result<TOut, TFailure>>> pipeAsync,
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
            input.InnerPipeParallelAsync(pipeAsync, option, pipeline.Configuration, cancellationToken);

        async ValueTask<Result<FlatArray<TOut>, TFailure>> InnerPipeCatchingAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
        {
            try
            {
                return await input.InnerPipeParallelAsync(
                    InnerPipeOrExceptionAsync, option, pipeline.Configuration, cancellationToken).ConfigureAwait(continueOnCapturedContext);
            }
            catch (InnerFailureException<TFailure> ex)
            {
                return ex.Failure;
            }
        }

        async Task<TOut> InnerPipeOrExceptionAsync(TIn input, CancellationToken cancellationToken)
        {
            var result = await pipeAsync.Invoke(input, cancellationToken).ConfigureAwait(continueOnCapturedContext);
            return result.SuccessOrThrow(InnerFailureException<TFailure>.From);
        }
    }

    private static Result<FlatArray<TOut>, TFailure> InnerJoinSuccess<TIn, TOut, TFailure>(
        FlatArray<Result<TOut, TFailure>> results)
        where TFailure : struct
    {
        var builder = FlatArray<TOut>.Builder.OfLength(results.Length);

        for (var i = 0; i < results.Length; i++)
        {
            var result = results[i];

            if (result.IsFailure)
            {
                return result.FailureOrThrow();
            }

            builder[i] = result.SuccessOrThrow();
        }

        return builder.MoveToFlatArray();
    }
}