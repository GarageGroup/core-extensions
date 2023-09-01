using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5), TFailure> ForwardParallel<TIn, T1, T2, T3, T4, T5, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, Task<Result<T1, TFailure>>> firstForwardAsync,
        Func<TIn, CancellationToken, Task<Result<T2, TFailure>>> secondForwardAsync,
        Func<TIn, CancellationToken, Task<Result<T3, TFailure>>> thirdForwardAsync,
        Func<TIn, CancellationToken, Task<Result<T4, TFailure>>> fourthForwardAsync,
        Func<TIn, CancellationToken, Task<Result<T5, TFailure>>> fifthForwardAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstForwardAsync);
        ArgumentNullException.ThrowIfNull(secondForwardAsync);
        ArgumentNullException.ThrowIfNull(thirdForwardAsync);
        ArgumentNullException.ThrowIfNull(fourthForwardAsync);
        ArgumentNullException.ThrowIfNull(fifthForwardAsync);

        return pipeline.MapSuccess(InnerForwardAsync).Forward(InnerJoinSuccess<TIn, T1, T2, T3, T4, T5, TFailure>);

        Task<(
            Result<T1, TFailure>,
            Result<T2, TFailure>,
            Result<T3, TFailure>,
            Result<T4, TFailure>,
            Result<T5, TFailure>
        )> InnerForwardAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(
                firstForwardAsync,
                secondForwardAsync,
                thirdForwardAsync,
                fourthForwardAsync,
                fifthForwardAsync,
                pipeline.Configuration,
                cancellationToken);
    }
}