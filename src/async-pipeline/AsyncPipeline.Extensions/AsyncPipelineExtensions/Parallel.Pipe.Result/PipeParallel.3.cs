using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TSuccess, TFailure> PipeParallel<TIn, TOut1, TOut2, TOut3, TSuccess, TFailure>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<Result<TOut1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut2, TFailure>>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut3, TFailure>>> thirdPipeAsync,
        Func<TOut1, TOut2, TOut3, TSuccess> fold)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fold);

        return pipeline.InnerPipeParallel(firstPipeAsync, secondPipeAsync, thirdPipeAsync, InnerFold).Pipe(InnerPipe);

        Result<TSuccess, TFailure> InnerFold(
            Result<TOut1, TFailure> firstResult,
            Result<TOut2, TFailure> secondResult,
            Result<TOut3, TFailure> thirdResult)
        {
            if (firstResult.IsFailure)
            {
                return firstResult.FailureOrThrow();
            }

            if (secondResult.IsFailure)
            {
                return secondResult.FailureOrThrow();
            }

            if (thirdResult.IsFailure)
            {
                return thirdResult.FailureOrThrow();
            }

            return fold.Invoke(
                firstResult.SuccessOrThrow(),
                secondResult.SuccessOrThrow(),
                thirdResult.SuccessOrThrow());
        }
    }
}