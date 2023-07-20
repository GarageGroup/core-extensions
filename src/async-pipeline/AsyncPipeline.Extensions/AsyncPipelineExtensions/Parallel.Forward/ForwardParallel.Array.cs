using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<FlatArray<TOut>, TFailure> ForwardParallel<TIn, TOut, TFailure>(
        this AsyncPipeline<FlatArray<TIn>, TFailure> pipeline,
        Func<TIn, CancellationToken, Task<Result<TOut, TFailure>>> forwardAsync,
        PipelineParallelOption option = default)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(forwardAsync);

        return pipeline.ForwardValue(InnerForwardAsync);

        ValueTask<Result<FlatArray<TOut>, TFailure>> InnerForwardAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(forwardAsync, option, cancellationToken);
    }
}