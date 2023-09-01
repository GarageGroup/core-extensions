using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4), TFailure> ForwardParallelValue<TIn, T1, T2, T3, T4, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, ValueTask<Result<T1, TFailure>>> firstForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T2, TFailure>>> secondForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T3, TFailure>>> thirdForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T4, TFailure>>> fourthForwardAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstForwardAsync);
        ArgumentNullException.ThrowIfNull(secondForwardAsync);
        ArgumentNullException.ThrowIfNull(thirdForwardAsync);
        ArgumentNullException.ThrowIfNull(fourthForwardAsync);

        return pipeline.MapSuccessValue(InnerForwardAsync).Forward(InnerJoinSuccess<TIn, T1, T2, T3, T4, TFailure>);

        ValueTask<(
            Result<T1, TFailure>,
            Result<T2, TFailure>,
            Result<T3, TFailure>,
            Result<T4, TFailure>
        )> InnerForwardAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelValueAsync(
                firstForwardAsync, secondForwardAsync, thirdForwardAsync, fourthForwardAsync, pipeline.Configuration, cancellationToken);
    }
}