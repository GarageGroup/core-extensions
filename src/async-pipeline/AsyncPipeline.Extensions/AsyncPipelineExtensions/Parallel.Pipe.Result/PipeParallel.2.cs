using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TSuccess, TFailure> PipeParallel<TIn, TOut1, TOut2, TSuccess, TFailure>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<Result<TOut1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<Result<TOut2, TFailure>>> secondPipeAsync,
        Func<TOut1, TOut2, TSuccess> fold)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(fold);

        return pipeline.InnerPipeParallel(firstPipeAsync, secondPipeAsync, InnerFold).Pipe(InnerPipe);

        Result<TSuccess, TFailure> InnerFold(Result<TOut1, TFailure> firstResult, Result<TOut2, TFailure> secondResult)
        {
            if (firstResult.IsFailure)
            {
                return firstResult.FailureOrThrow();
            }

            if (secondResult.IsFailure)
            {
                return secondResult.FailureOrThrow();
            }

            return fold.Invoke(firstResult.SuccessOrThrow(), secondResult.SuccessOrThrow());
        }
    }
}