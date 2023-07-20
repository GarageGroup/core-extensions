using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2), TFailure> ForwardParallel<TIn, T1, T2, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, Task<Result<T1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T2, TFailure>>> secondPipeAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);

        return pipeline.Forward(InnerPipeAsync);

        async Task<Result<(T1, T2), TFailure>> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
        {
            var firstTask = firstPipeAsync.Invoke(input, cancellationToken);
            var secondTask = secondPipeAsync.Invoke(input, cancellationToken);

            await Task.WhenAll(firstTask, secondTask).ConfigureAwait(false);

            var firstResult = await firstTask.ConfigureAwait(false);
            if (firstResult.IsFailure)
            {
                return firstResult.FailureOrThrow();
            }

            var secondResult = await secondTask.ConfigureAwait(false);
            if (secondResult.IsFailure)
            {
                return secondResult.FailureOrThrow();
            }

            return (firstResult.SuccessOrThrow(), secondResult.SuccessOrThrow());
        }
    }
}