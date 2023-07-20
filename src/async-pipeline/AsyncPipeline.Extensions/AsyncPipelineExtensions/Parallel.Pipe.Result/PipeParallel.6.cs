using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5, T6), TFailure> PipeParallel<TIn, T1, T2, T3, T4, T5, T6, TFailure>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<Result<T1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T2, TFailure>>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T3, TFailure>>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T4, TFailure>>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T5, TFailure>>> fifthPipeAsync,
        Func<TIn, CancellationToken, Task<Result<T6, TFailure>>> sixthPipeAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fifthPipeAsync);
        ArgumentNullException.ThrowIfNull(sixthPipeAsync);

        return pipeline
            .InnerPipeParallel(
                firstPipeAsync, secondPipeAsync, thirdPipeAsync, fourthPipeAsync, fifthPipeAsync, sixthPipeAsync)
            .Pipe(
                InnerFold);

        static Result<(T1, T2, T3, T4, T5, T6), TFailure> InnerFold(
            (
                Result<T1, TFailure> First,
                Result<T2, TFailure> Second,
                Result<T3, TFailure> Third,
                Result<T4, TFailure> Fourth,
                Result<T5, TFailure> Fifth,
                Result<T6, TFailure> Sixth
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

            return (
                result.First.SuccessOrThrow(),
                result.Second.SuccessOrThrow(),
                result.Third.SuccessOrThrow(),
                result.Fourth.SuccessOrThrow(),
                result.Fifth.SuccessOrThrow(),
                result.Sixth.SuccessOrThrow());
        }
    }
}