using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TSuccess, TFailure> PipeParallel<TIn, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TOut8, TSuccess, TFailure>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<Result<TOut1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut2, TFailure>>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut3, TFailure>>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut4, TFailure>>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut5, TFailure>>> fifthPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut6, TFailure>>> sixthPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut7, TFailure>>> seventhPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut8, TFailure>>> eigthPipeAsync,
        Func<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TOut7, TOut8, TSuccess> fold)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fifthPipeAsync);
        ArgumentNullException.ThrowIfNull(sixthPipeAsync);
        ArgumentNullException.ThrowIfNull(seventhPipeAsync);
        ArgumentNullException.ThrowIfNull(eigthPipeAsync);
        ArgumentNullException.ThrowIfNull(fold);

        return pipeline
            .InnerPipeParallel(
                firstPipeAsync, secondPipeAsync, thirdPipeAsync, fourthPipeAsync, fifthPipeAsync,
                sixthPipeAsync, seventhPipeAsync, eigthPipeAsync, InnerFold)
            .Pipe(InnerPipe);

        Result<TSuccess, TFailure> InnerFold(
            Result<TOut1, TFailure> firstResult,
            Result<TOut2, TFailure> secondResult,
            Result<TOut3, TFailure> thirdResult,
            Result<TOut4, TFailure> fourthResult,
            Result<TOut5, TFailure> fifthResult,
            Result<TOut6, TFailure> sixthResult,
            Result<TOut7, TFailure> seventhResult,
            Result<TOut8, TFailure> eigthResult)
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

            if (sixthResult.IsFailure)
            {
                return sixthResult.FailureOrThrow();
            }

            if (seventhResult.IsFailure)
            {
                return seventhResult.FailureOrThrow();
            }

            if (eigthResult.IsFailure)
            {
                return eigthResult.FailureOrThrow();
            }

            return fold.Invoke(
                firstResult.SuccessOrThrow(),
                secondResult.SuccessOrThrow(),
                thirdResult.SuccessOrThrow(),
                fourthResult.SuccessOrThrow(),
                fifthResult.SuccessOrThrow(),
                sixthResult.SuccessOrThrow(),
                seventhResult.SuccessOrThrow(),
                eigthResult.SuccessOrThrow());
        }
    }
}