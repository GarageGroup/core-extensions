using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2)> PipeParallelValue<TIn, T1, T2>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, ValueTask<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T2>> secondPipeAsync)
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);

        return pipeline.InnerPipeParallelValue(firstPipeAsync, secondPipeAsync);
    }

    private static AsyncPipeline<(T1, T2)> InnerPipeParallelValue<TIn, T1, T2>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, ValueTask<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T2>> secondPipeAsync)
    {
        return pipeline.PipeValue(InnerPipeAsync);

        ValueTask<(T1, T2)> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelValueAsync(firstPipeAsync, secondPipeAsync, pipeline.Configuration, cancellationToken);
    }

    private static async ValueTask<(T1, T2)> InnerPipeParallelValueAsync<TIn, T1, T2>(
        this TIn input,
        Func<TIn, CancellationToken, ValueTask<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T2>> secondPipeAsync,
        AsyncPipelineConfiguration configuration,
        CancellationToken cancellationToken)
    {
        T1 first = default!;
        T2 second = default!;

        var options = configuration.InnerCreateParallelOptions(null, cancellationToken);
        await Parallel.ForEachAsync(Enumerable.Range(0, 2), options, InnerInvokeAsync).ConfigureAwait(configuration.ContinueOnCapturedContext);

        return (first, second);

        async ValueTask InnerInvokeAsync(int index, CancellationToken cancellationToken)
        {
            switch (index)
            {
                case 0:
                first = await firstPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(configuration.ContinueOnCapturedContext);
                break;

                case 1:
                second = await secondPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(configuration.ContinueOnCapturedContext);
                break;

                default:
                throw CreateIndexOutOfRangeException(index);
            };
        }
    }
}