using System;
using System.Threading;
using System.Threading.Tasks;

namespace GGroupp;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TSuccess, TFailure> PipeParallel<TIn, TOut1, TOut2, TOut3, TOut4, TOut5, TSuccess, TFailure>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<Result<TOut1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut2, TFailure>>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut3, TFailure>>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut4, TFailure>>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut5, TFailure>>> fifthPipeAsync,
        Func<TOut1, TOut2, TOut3, TOut4, TOut5, TSuccess> fold)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fifthPipeAsync);
        ArgumentNullException.ThrowIfNull(fold);

        return pipeline.InnerPipeParallel(firstPipeAsync, secondPipeAsync, thirdPipeAsync, fourthPipeAsync, fifthPipeAsync, InnerFold)
            .Pipe(InnerPipe);

        Result<TSuccess, TFailure> InnerFold(
            Result<TOut1, TFailure> firstResult,
            Result<TOut2, TFailure> secondResult,
            Result<TOut3, TFailure> thirdResult,
            Result<TOut4, TFailure> fourthResult,
            Result<TOut5, TFailure> fifthResult)
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

            if (fourthResult.IsFailure)
            {
                return fourthResult.FailureOrThrow();
            }

            if (fifthResult.IsFailure)
            {
                return fifthResult.FailureOrThrow();
            }

            return fold.Invoke(
                firstResult.SuccessOrThrow(),
                secondResult.SuccessOrThrow(),
                thirdResult.SuccessOrThrow(),
                fourthResult.SuccessOrThrow(),
                fifthResult.SuccessOrThrow());
        }
    }
}