using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2)> PipeParallel<TIn, T1, T2>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync)
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);

        return pipeline.InnerPipeParallel(firstPipeAsync, secondPipeAsync);
    }

    private static AsyncPipeline<(T1, T2)> InnerPipeParallel<TIn, T1, T2>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync)
    {
        return pipeline.Pipe(InnerPipeAsync);

        Task<(T1, T2)> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(firstPipeAsync, secondPipeAsync, pipeline.Configuration, cancellationToken);
    }

    private static async Task<(T1, T2)> InnerPipeParallelAsync<TIn, T1, T2>(
        this TIn input,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
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