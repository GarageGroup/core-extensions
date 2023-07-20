using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4), TFailure> PipeParallel<TIn, T1, T2, T3, T4, TFailure>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<Result<T1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T2, TFailure>>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T3, TFailure>>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T4, TFailure>>> fourthPipeAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);

        return pipeline.InnerPipeParallel(
            firstPipeAsync, secondPipeAsync, thirdPipeAsync, fourthPipeAsync)
        .Pipe(
            InnerJoinSuccess<TIn, T1, T2, T3, T4, TFailure>);
    }

    private static Result<(T1, T2, T3, T4), TFailure> InnerJoinSuccess<TIn, T1, T2, T3, T4, TFailure>(
        (
            Result<T1, TFailure> First,
            Result<T2, TFailure> Second,
            Result<T3, TFailure> Third,
            Result<T4, TFailure> Fourth
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

        return (
            result.First.SuccessOrThrow(),
            result.Second.SuccessOrThrow(),
            result.Third.SuccessOrThrow(),
            result.Fourth.SuccessOrThrow());
    }
}