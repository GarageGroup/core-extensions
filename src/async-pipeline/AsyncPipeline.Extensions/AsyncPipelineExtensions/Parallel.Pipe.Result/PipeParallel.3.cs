using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3), TFailure> PipeParallel<TIn, T1, T2, T3, TFailure>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<Result<T1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T2, TFailure>>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T3, TFailure>>> thirdPipeAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);

        return pipeline
            .InnerPipeParallel(
                firstPipeAsync, secondPipeAsync, thirdPipeAsync)
            .Pipe(
                InnerFold);

        static Result<(T1, T2, T3), TFailure> InnerFold(
            (
                Result<T1, TFailure> First,
                Result<T2, TFailure> Second,
                Result<T3, TFailure> Third
            ) result)
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

            return (
                result.First.SuccessOrThrow(),
                result.Second.SuccessOrThrow(),
                result.Third.SuccessOrThrow());
        }
    }
}