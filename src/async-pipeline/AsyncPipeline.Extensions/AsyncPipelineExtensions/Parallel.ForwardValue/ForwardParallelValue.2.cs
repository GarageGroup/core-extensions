using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2), TFailure> ForwardParallelValue<TIn, T1, T2, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, ValueTask<Result<T1, TFailure>>> firstForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T2, TFailure>>> secondForwardAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstForwardAsync);
        ArgumentNullException.ThrowIfNull(secondForwardAsync);

        return pipeline.MapSuccessValue(InnerForwardAsync).Forward(InnerJoinSuccess<TIn, T1, T2, TFailure>);

        ValueTask<(
            Result<T1, TFailure>,
            Result<T2, TFailure>
        )> InnerForwardAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelValueAsync(
                firstForwardAsync, secondForwardAsync, pipeline.Configuration, cancellationToken);
    }
}