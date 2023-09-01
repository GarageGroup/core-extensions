using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<FlatArray<TOut>> PipeParallel<TIn, TOut>(
        this AsyncPipeline<FlatArray<TIn>> pipeline,
        Func<TIn, CancellationToken, Task<TOut>> pipeAsync,
        [AllowNull] PipelineParallelOption option = default)
    {
        ArgumentNullException.ThrowIfNull(pipeAsync);

        return pipeline.PipeValue(InnerPipeAsync);

        ValueTask<FlatArray<TOut>> InnerPipeAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(pipeAsync, option, pipeline.Configuration, cancellationToken);
    }

    private static async ValueTask<FlatArray<TOut>> InnerPipeParallelAsync<TIn, TOut>(
        this FlatArray<TIn> input,
        Func<TIn, CancellationToken, Task<TOut>> pipeAsync,
        PipelineParallelOption? option,
        AsyncPipelineConfiguration pipelineConfiguration,
        CancellationToken cancellationToken)
    {
        if (input.IsEmpty)
        {
            return default;
        }

        var items = new ConcurrentBag<(int Index, TOut Value)>();

        var options = pipelineConfiguration.InnerCreateParallelOptions(option?.DegreeOfParallelism, cancellationToken);
        var continueOnCapturedContext = pipelineConfiguration.ContinueOnCapturedContext;

        await Parallel.ForEachAsync(Enumerable.Range(0, input.Length), options, InnerInvokeAsync).ConfigureAwait(continueOnCapturedContext);

        return items.OrderBy(GetIndex).Select(GetValue).ToFlatArray();

        async ValueTask InnerInvokeAsync(int index, CancellationToken cancellationToken)
        {
            var value = await pipeAsync.Invoke(input[index], cancellationToken).ConfigureAwait(continueOnCapturedContext);
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