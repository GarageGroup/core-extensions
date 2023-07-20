using System;
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

        if (option.DegreeOfParallelism is not > 0)
        {
            return await Task.WhenAll(input.AsEnumerable().Select(InnerPipeAsync)).ConfigureAwait(false);
        }

        var builder = FlatArray<TOut>.Builder.OfLength(input.Length);

        if (option.DegreeOfParallelism is 1)
        {
            for (var i = 0; i < input.Length; i++)
            {
                builder[i] = await pipeAsync.Invoke(input[i], cancellationToken).ConfigureAwait(false);
            }

            return builder.MoveToFlatArray();
        }

        var index = 0;

        foreach (var chunk in input.ToArray().SplitIntoChunks(option.DegreeOfParallelism.Value))
        {
            var items = await Task.WhenAll(chunk.Select(InnerPipeAsync)).ConfigureAwait(false);

            foreach (var item in items)
            {
                builder[index] = item;
                index++;
            }
        }

        return builder.MoveToFlatArray();

        Task<TOut> InnerPipeAsync(TIn @in)
            =>
            pipeAsync.Invoke(@in, cancellationToken);
    }
}