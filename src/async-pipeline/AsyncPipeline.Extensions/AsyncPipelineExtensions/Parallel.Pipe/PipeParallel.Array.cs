using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<FlatArray<TOut>> PipeParallel<TIn, TOut>(
        this AsyncPipeline<FlatArray<TIn>> pipeline,
        Func<TIn, CancellationToken, Task<TOut>> pipeAsync,
        PipelineParallelOption option = default)
    {
        ArgumentNullException.ThrowIfNull(pipeAsync);

        return pipeline.PipeValue(InnerPipeAsync);

        ValueTask<FlatArray<TOut>> InnerPipeAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(pipeAsync, option, cancellationToken);
    }

    private static async ValueTask<FlatArray<TOut>> InnerPipeParallelAsync<TIn, TOut>(
        this FlatArray<TIn> input,
        Func<TIn, CancellationToken, Task<TOut>> pipeAsync,
        PipelineParallelOption option,
        CancellationToken cancellationToken)
    {
        if (input.IsEmpty)
        {
            return default;
        }

        var items = new ConcurrentBag<(int Index, TOut Value)>();

        var parallelOptions = new ParallelOptions
        {
            CancellationToken = cancellationToken
        };

        if (option.DegreeOfParallelism > 0)
        {
            parallelOptions.MaxDegreeOfParallelism = option.DegreeOfParallelism.Value;
        }

        await Parallel.ForEachAsync(Enumerable.Range(0, input.Length), parallelOptions, InnerInvokeAsync).ConfigureAwait(false);

        return items.OrderBy(GetIndex).Select(GetValue).ToFlatArray();

        async ValueTask InnerInvokeAsync(int index, CancellationToken cancellationToken)
        {
            var value = await pipeAsync.Invoke(input[index], cancellationToken).ConfigureAwait(false);
            items.Add((index, value));
        }

        static int GetIndex((int Index, TOut) item)
            =>
            item.Index;

        static TOut GetValue((int, TOut Value) item)
            =>
            item.Value;
    }
}