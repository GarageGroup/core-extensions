using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5, T6), TFailure> ForwardParallelValue<TIn, T1, T2, T3, T4, T5, T6, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, ValueTask<Result<T1, TFailure>>> firstForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T2, TFailure>>> secondForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T3, TFailure>>> thirdForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T4, TFailure>>> fourthForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T5, TFailure>>> fifthForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T6, TFailure>>> sixthForwardAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstForwardAsync);
        ArgumentNullException.ThrowIfNull(secondForwardAsync);
        ArgumentNullException.ThrowIfNull(thirdForwardAsync);
        ArgumentNullException.ThrowIfNull(fourthForwardAsync);
        ArgumentNullException.ThrowIfNull(fifthForwardAsync);
        ArgumentNullException.ThrowIfNull(sixthForwardAsync);

        return pipeline.MapSuccessValue(InnerForwardAsync).Forward(InnerJoinSuccess<TIn, T1, T2, T3, T4, T5, T6, TFailure>);

        ValueTask<(
            Result<T1, TFailure>,
            Result<T2, TFailure>,
            Result<T3, TFailure>,
            Result<T4, TFailure>,
            Result<T5, TFailure>,
            Result<T6, TFailure>
        )> InnerForwardAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelValueAsync(
                firstForwardAsync,
                secondForwardAsync,
                thirdForwardAsync,
                fourthForwardAsync,
                fifthForwardAsync,
                sixthForwardAsync,
                pipeline.Configuration,
                cancellationToken);
    }
}