using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5, T6, T7), TFailure> PipeParallel<TIn, T1, T2, T3, T4, T5, T6, T7, TFailure>(
        this AsyncPipeline<TIn> pipeline,
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

        return pipeline.InnerPipeParallel(
            firstPipeAsync, secondPipeAsync, thirdPipeAsync, fourthPipeAsync, fifthPipeAsync, sixthPipeAsync, seventhPipeAsync)
        .Pipe(
            InnerJoinSuccess<TIn, T1, T2, T3, T4, T5, T6, T7, TFailure>);
    }

    private static Result<(T1, T2, T3, T4, T5, T6, T7), TFailure> InnerJoinSuccess<TIn, T1, T2, T3, T4, T5, T6, T7, TFailure>(
        (
            Result<T1, TFailure> First,
            Result<T2, TFailure> Second,
            Result<T3, TFailure> Third,
            Result<T4, TFailure> Fourth,
            Result<T5, TFailure> Fifth,
            Result<T6, TFailure> Sixth,
            Result<T7, TFailure> Seventh
        ) result)
    where TFailure : struct
    {
        if (result.First.IsFailure)
        {
            return result.First.FailureOrThrow();
        }

        if (result.Second.IsFailure)
        {
            return result.Second.FailureOrThrow();
        }

        if (result.Third.IsFailure)
        {
            return result.Third.FailureOrThrow();
        }

        if (result.Fourth.IsFailure)
        {
            return result.Fourth.FailureOrThrow();
        }

        if (result.Fifth.IsFailure)
        {
            return result.Fifth.FailureOrThrow();
        }

        if (result.Sixth.IsFailure)
        {
            return result.Sixth.FailureOrThrow();
        }

        if (result.Seventh.IsFailure)
        {
            return result.Seventh.FailureOrThrow();
        }

        return (
            result.First.SuccessOrThrow(),
            result.Second.SuccessOrThrow(),
            result.Third.SuccessOrThrow(),
            result.Fourth.SuccessOrThrow(),
            result.Fifth.SuccessOrThrow(),
            result.Sixth.SuccessOrThrow(),
            result.Seventh.SuccessOrThrow());
    }
}