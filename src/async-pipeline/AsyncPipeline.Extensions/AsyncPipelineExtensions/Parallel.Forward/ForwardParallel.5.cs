using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5), TFailure> ForwardParallel<TIn, T1, T2, T3, T4, T5, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, Task<Result<T1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T2, TFailure>>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T3, TFailure>>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T4, TFailure>>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T5, TFailure>>> fifthPipeAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fifthPipeAsync);

        return pipeline.Forward(InnerPipeAsync);

        async Task<Result<(T1, T2, T3, T4, T5), TFailure>> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
        {
            var firstTask = firstPipeAsync.Invoke(input, cancellationToken);
            var secondTask = secondPipeAsync.Invoke(input, cancellationToken);
            var thirdTask = thirdPipeAsync.Invoke(input, cancellationToken);
            var fourthTask = fourthPipeAsync.Invoke(input, cancellationToken);
            var fifthTask = fifthPipeAsync.Invoke(input, cancellationToken);

            await Task.WhenAll(firstTask, secondTask, thirdTask, fourthTask, fifthTask).ConfigureAwait(false);

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

            var thirdResult = await thirdTask.ConfigureAwait(false);
            if (thirdResult.IsFailure)
            {
                return thirdResult.FailureOrThrow();
            }

            var fourthResult = await fourthTask.ConfigureAwait(false);
            if (fourthResult.IsFailure)
            {
                return fourthResult.FailureOrThrow();
            }

            var fifthResult = await fifthTask.ConfigureAwait(false);
            if (fifthResult.IsFailure)
            {
                return fifthResult.FailureOrThrow();
            }

            return (
                firstResult.SuccessOrThrow(),
                secondResult.SuccessOrThrow(),
                thirdResult.SuccessOrThrow(),
                fourthResult.SuccessOrThrow(),
                fifthResult.SuccessOrThrow());
        }
    }
}