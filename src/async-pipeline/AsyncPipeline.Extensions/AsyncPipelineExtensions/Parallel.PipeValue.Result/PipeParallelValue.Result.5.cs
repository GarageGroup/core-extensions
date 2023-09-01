using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5), TFailure> PipeParallelValue<TIn, T1, T2, T3, T4, T5, TFailure>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, ValueTask<Result<T1, TFailure>>> firstPipeAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T2, TFailure>>> secondPipeAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T3, TFailure>>> thirdPipeAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T4, TFailure>>> fourthPipeAsync,
        Func<TIn, CancellationToken, ValueTask<Result<T5, TFailure>>> fifthPipeAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fifthPipeAsync);

        return pipeline.InnerPipeParallelValue(
            firstPipeAsync, secondPipeAsync, thirdPipeAsync, fourthPipeAsync, fifthPipeAsync)
        .Pipe(
            InnerJoinSuccess<TIn, T1, T2, T3, T4, T5, TFailure>);
    }
}