using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5, T6, T7), TFailure> ForwardParallel<TIn, T1, T2, T3, T4, T5, T6, T7, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, Task<Result<T1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T2, TFailure>>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T3, TFailure>>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T4, TFailure>>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T5, TFailure>>> fifthPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T6, TFailure>>> sixthPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T7, TFailure>>> seventhPipeAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fifthPipeAsync);
        ArgumentNullException.ThrowIfNull(sixthPipeAsync);
        ArgumentNullException.ThrowIfNull(seventhPipeAsync);

        return pipeline.Forward(InnerPipeAsync);

        async Task<Result<(T1, T2, T3, T4, T5, T6, T7), TFailure>> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
        {
            var firstTask = firstPipeAsync.Invoke(input, cancellationToken);
            var secondTask = secondPipeAsync.Invoke(input, cancellationToken);
            var thirdTask = thirdPipeAsync.Invoke(input, cancellationToken);
            var fourthTask = fourthPipeAsync.Invoke(input, cancellationToken);
            var fifthTask = fifthPipeAsync.Invoke(input, cancellationToken);
            var sixthTask = sixthPipeAsync.Invoke(input, cancellationToken);
            var seventhTask = seventhPipeAsync.Invoke(input, cancellationToken);

            await Task.WhenAll(firstTask, secondTask, thirdTask, fourthTask, fifthTask, sixthTask, seventhTask).ConfigureAwait(false);

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

            var sixthResult = await sixthTask.ConfigureAwait(false);
            if (sixthResult.IsFailure)
            {
                return sixthResult.FailureOrThrow();
            }

            var seventhResult = await seventhTask.ConfigureAwait(false);
            if (seventhResult.IsFailure)
            {
                return seventhResult.FailureOrThrow();
            }

            return (
                firstResult.SuccessOrThrow(),
                secondResult.SuccessOrThrow(),
                thirdResult.SuccessOrThrow(),
                fourthResult.SuccessOrThrow(),
                fifthResult.SuccessOrThrow(),
                sixthResult.SuccessOrThrow(),
                seventhResult.SuccessOrThrow());
        }
    }
}