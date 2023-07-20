using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3)> PipeParallel<TIn, T1, T2, T3>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync)
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);

        return pipeline.InnerPipeParallel(
            firstPipeAsync,
            secondPipeAsync,
            thirdPipeAsync);
    }

    private static AsyncPipeline<(T1, T2, T3)> InnerPipeParallel<TIn, T1, T2, T3>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync)
    {
        return pipeline.Pipe(InnerPipeAsync);

        async Task<(T1, T2, T3)> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
        {
            var firstTask = firstPipeAsync.Invoke(input, cancellationToken);
            var secondTask = secondPipeAsync.Invoke(input, cancellationToken);
            var thirdTask = thirdPipeAsync.Invoke(input, cancellationToken);

            await Task.WhenAll(firstTask, secondTask, thirdTask).ConfigureAwait(false);

            return (
                await firstTask.ConfigureAwait(false),
                await secondTask.ConfigureAwait(false),
                await thirdTask.ConfigureAwait(false));
        }
    }
}