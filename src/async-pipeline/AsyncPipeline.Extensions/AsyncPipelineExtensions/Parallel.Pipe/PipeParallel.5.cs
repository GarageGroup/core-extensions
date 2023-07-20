using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5)> PipeParallel<TIn, T1, T2, T3, T4, T5>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<T4>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<T5>> fifthPipeAsync)
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fifthPipeAsync);

        return pipeline.InnerPipeParallel(
            firstPipeAsync,
            secondPipeAsync,
            thirdPipeAsync,
            fourthPipeAsync,
            fifthPipeAsync);
    }

    private static AsyncPipeline<(T1, T2, T3, T4, T5)> InnerPipeParallel<TIn, T1, T2, T3, T4, T5>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<T4>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<T5>> fifthPipeAsync)
    {
        return pipeline.Pipe(InnerPipeAsync);

        Task<(T1, T2, T3, T4, T5)> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(
                firstPipeAsync, secondPipeAsync, thirdPipeAsync, fourthPipeAsync, fifthPipeAsync, cancellationToken);
    }

    private static async Task<(T1, T2, T3, T4, T5)> InnerPipeParallelAsync<TIn, T1, T2, T3, T4, T5>(
        this TIn input,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<T4>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<T5>> fifthPipeAsync,
        CancellationToken cancellationToken)
    {
        T1 first = default!;
        T2 second = default!;
        T3 third = default!;
        T4 fourth = default!;
        T5 fifth = default!;

        await Parallel.ForEachAsync(
            source: Enumerable.Range(0, 5),
            cancellationToken: cancellationToken,
            body: InnerInvokeAsync);

        return (first, second, third, fourth, fifth);

        async ValueTask InnerInvokeAsync(int index, CancellationToken cancellationToken)
        {
            switch (index)
            {
                case 0:
                first = await firstPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(false);
                break;

                case 1:
                second = await secondPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(false);
                break;

                case 2:
                third = await thirdPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(false);
                break;

                case 3:
                fourth = await fourthPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(false);
                break;

                case 4:
                fifth = await fifthPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(false);
                break;

                default:
                throw CreateIndexOutOfRangeException(index);
            };
        }
    }
}