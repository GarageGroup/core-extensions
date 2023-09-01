using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2), TFailure> ForwardParallel<TIn, T1, T2, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, Task<Result<T1, TFailure>>> firstForwardAsync,
        Func<TIn, CancellationToken, Task<Result<T2, TFailure>>> secondForwardAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstForwardAsync);
        ArgumentNullException.ThrowIfNull(secondForwardAsync);

        return pipeline.MapSuccess(InnerForwardAsync).Forward(InnerJoinSuccess<TIn, T1, T2, TFailure>);

        Task<(
            Result<T1, TFailure>,
            Result<T2, TFailure>
        )> InnerForwardAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(
                firstForwardAsync, secondForwardAsync, pipeline.Configuration, cancellationToken);
    }
}