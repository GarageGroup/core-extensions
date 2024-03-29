using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5, T6, T7, T8), TFailure> ForwardParallelValue<TIn, T1, T2, T3, T4, T5, T6, T7, T8, TFailure>(
        this AsyncPipeline<TIn, TFailure> pipeline,
        Func<TIn, CancellationToken, ValueTask<Result<T1, TFailure>>> firstForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T2, TFailure>>> secondForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T3, TFailure>>> thirdForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T4, TFailure>>> fourthForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T5, TFailure>>> fifthForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T6, TFailure>>> sixthForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T7, TFailure>>> seventhForwardAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T8, TFailure>>> eighthForwardAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstForwardAsync);
        ArgumentNullException.ThrowIfNull(secondForwardAsync);
        ArgumentNullException.ThrowIfNull(thirdForwardAsync);
        ArgumentNullException.ThrowIfNull(fourthForwardAsync);
        ArgumentNullException.ThrowIfNull(fifthForwardAsync);
        ArgumentNullException.ThrowIfNull(sixthForwardAsync);
        ArgumentNullException.ThrowIfNull(seventhForwardAsync);
        ArgumentNullException.ThrowIfNull(eighthForwardAsync);

        return pipeline.MapSuccessValue(InnerForwardAsync).Forward(InnerJoinSuccess<TIn, T1, T2, T3, T4, T5, T6, T7, T8, TFailure>);

        ValueTask<(
            Result<T1, TFailure>,
            Result<T2, TFailure>,
            Result<T3, TFailure>,
            Result<T4, TFailure>,
            Result<T5, TFailure>,
            Result<T6, TFailure>,
            Result<T7, TFailure>,
            Result<T8, TFailure>
        )> InnerForwardAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelValueAsync(
                firstForwardAsync,
                secondForwardAsync,
                thirdForwardAsync,
                fourthForwardAsync,
                fifthForwardAsync,
                sixthForwardAsync,
                seventhForwardAsync,
                eighthForwardAsync,
                pipeline.Configuration,
                cancellationToken);
    }
}