using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2), TFailure> PipeParallel<TIn, T1, T2, TFailure>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<Result<T1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T2, TFailure>>> secondPipeAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);

        return pipeline.InnerPipeParallel(
            firstPipeAsync, secondPipeAsync)
        .Pipe(
            InnerJoinSuccess<TIn, T1, T2, TFailure>);
    }

    private static Result<(T1, T2), TFailure> InnerJoinSuccess<TIn, T1, T2, TFailure>(
        (
            Result<T1, TFailure> First,
            Result<T2, TFailure> Second
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

        return (
            result.First.SuccessOrThrow(),
            result.Second.SuccessOrThrow());
    }
}