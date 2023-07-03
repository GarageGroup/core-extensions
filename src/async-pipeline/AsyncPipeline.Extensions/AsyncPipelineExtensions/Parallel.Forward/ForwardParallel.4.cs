using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TSuccess, TFailure> ForwardParallel<TIn, TOut1, TOut2, TOut3, TOut4, TSuccess, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, Task<Result<TOut1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut2, TFailure>>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut3, TFailure>>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut4, TFailure>>> fourthPipeAsync,
        Func<TOut1, TOut2, TOut3, TOut4, TSuccess> fold)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fold);

        return pipeline.Forward(InnerPipeAsync);

        async Task<Result<TSuccess, TFailure>> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
        {
            var firstTask = firstPipeAsync.Invoke(input, cancellationToken);
            var secondTask = secondPipeAsync.Invoke(input, cancellationToken);
            var thirdTask = thirdPipeAsync.Invoke(input, cancellationToken);
            var fourthTask = fourthPipeAsync.Invoke(input, cancellationToken);

            await Task.WhenAll(firstTask, secondTask, thirdTask, fourthTask).ConfigureAwait(false);

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

            var thirdResult = thirdTask.Result;
            if (thirdResult.IsFailure)
            {
                return thirdResult.FailureOrThrow();
            }

            var fourthResult = fourthTask.Result;
            if (fourthResult.IsFailure)
            {
                return fourthResult.FailureOrThrow();
            }

            return fold.Invoke(
                firstResult.SuccessOrThrow(),
                secondResult.SuccessOrThrow(),
                thirdResult.SuccessOrThrow(),
                fourthResult.SuccessOrThrow());
        }
    }
}