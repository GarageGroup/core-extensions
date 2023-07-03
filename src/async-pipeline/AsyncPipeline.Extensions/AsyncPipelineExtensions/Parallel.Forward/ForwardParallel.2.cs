using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TSuccess, TFailure> ForwardParallel<TIn, TOut1, TOut2, TSuccess, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, Task<Result<TOut1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut2, TFailure>>> secondPipeAsync,
        Func<TOut1, TOut2, TSuccess> fold)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(fold);

        return pipeline.Forward(InnerPipeAsync);

        async Task<Result<TSuccess, TFailure>> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
        {
            var firstTask = firstPipeAsync.Invoke(input, cancellationToken);
            var secondTask = secondPipeAsync.Invoke(input, cancellationToken);

            await Task.WhenAll(firstTask, secondTask).ConfigureAwait(false);

            var firstResult = firstTask.Result;
            if (firstResult.IsFailure)
            {
                return firstResult.FailureOrThrow();
            }

            var secondResult = secondTask.Result;
            if (secondResult.IsFailure)
            {
                return secondResult.FailureOrThrow();
            }

            return fold.Invoke(firstResult.SuccessOrThrow(), secondResult.SuccessOrThrow());
        }
    }
}