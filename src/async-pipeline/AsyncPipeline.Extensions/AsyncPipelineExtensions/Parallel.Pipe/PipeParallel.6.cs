using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5, T6)> PipeParallel<TIn, T1, T2, T3, T4, T5, T6>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<T4>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<T5>> fifthPipeAsync,
        Func<TIn, CancellationToken, Task<T6>> sixthPipeAsync)
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fifthPipeAsync);
        ArgumentNullException.ThrowIfNull(sixthPipeAsync);

        return pipeline.InnerPipeParallel(
            firstPipeAsync,
            secondPipeAsync,
            thirdPipeAsync,
            fourthPipeAsync,
            fifthPipeAsync,
            sixthPipeAsync);
    }

    private static AsyncPipeline<(T1, T2, T3, T4, T5, T6)> InnerPipeParallel<TIn, T1, T2, T3, T4, T5, T6>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<T4>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<T5>> fifthPipeAsync,
        Func<TIn, CancellationToken, Task<T6>> sixthPipeAsync)
    {
        return pipeline.Pipe(InnerPipeAsync);

        async Task<(T1, T2, T3, T4, T5, T6)> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
        {
            var firstTask = firstPipeAsync.Invoke(input, cancellationToken);
            var secondTask = secondPipeAsync.Invoke(input, cancellationToken);
            var thirdTask = thirdPipeAsync.Invoke(input, cancellationToken);
            var fourthTask = fourthPipeAsync.Invoke(input, cancellationToken);
            var fifthTask = fifthPipeAsync.Invoke(input, cancellationToken);
            var sixthTask = sixthPipeAsync.Invoke(input, cancellationToken);

            await Task.WhenAll(firstTask, secondTask, thirdTask, fourthTask, fifthTask, sixthTask).ConfigureAwait(false);

            return (
                await firstTask.ConfigureAwait(false),
                await secondTask.ConfigureAwait(false),
                await thirdTask.ConfigureAwait(false),
                await fourthTask.ConfigureAwait(false),
                await fifthTask.ConfigureAwait(false),
                await sixthTask.ConfigureAwait(false));
        }
    }
}