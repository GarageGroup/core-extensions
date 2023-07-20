using System;
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

        async Task<(T1, T2)> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
        {
            var firstTask = firstPipeAsync.Invoke(input, cancellationToken);
            var secondTask = secondPipeAsync.Invoke(input, cancellationToken);

            await Task.WhenAll(firstTask, secondTask).ConfigureAwait(false);

            return (
                await firstTask.ConfigureAwait(false),
                await secondTask.ConfigureAwait(false));
        }
    }
}