using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<Unit> PipeParallelValue<TIn>(
        this AsyncPipeline<FlatArray<TIn>> pipeline,
        Func<TIn, CancellationToken, ValueTask<Unit>> pipeAsync,
        [AllowNull] PipelineParallelOption option = default)
    {
        ArgumentNullException.ThrowIfNull(pipeAsync);

        return pipeline.PipeValue(InnerPipeAsync);

        ValueTask<Unit> InnerPipeAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelValueAsync(pipeAsync, option, pipeline.Configuration, cancellationToken);
    }

    private static async ValueTask<Unit> InnerPipeParallelValueAsync<TIn>(
        this FlatArray<TIn> input,
        Func<TIn, CancellationToken, ValueTask<Unit>> pipeAsync,
        PipelineParallelOption? option,
        AsyncPipelineConfiguration pipelineConfiguration,
        CancellationToken cancellationToken)
    {
        if (input.IsEmpty)
        {
            return default;
        }

        var continueOnCapturedContext = pipelineConfiguration.ContinueOnCapturedContext;
        if (input.Length is 1)
        {
            return await pipeAsync.Invoke(input[0], cancellationToken).ConfigureAwait(continueOnCapturedContext);
        }

        var options = pipelineConfiguration.InnerCreateParallelOptions(option?.DegreeOfParallelism, cancellationToken);
        await Parallel.ForEachAsync(input.AsEnumerable(), options, InnerInvokeAsync).ConfigureAwait(continueOnCapturedContext);

        return default;

        async ValueTask InnerInvokeAsync(TIn @in, CancellationToken cancellationToken)
            =>
            _ = await pipeAsync.Invoke(@in, cancellationToken).ConfigureAwait(continueOnCapturedContext);
    }
}