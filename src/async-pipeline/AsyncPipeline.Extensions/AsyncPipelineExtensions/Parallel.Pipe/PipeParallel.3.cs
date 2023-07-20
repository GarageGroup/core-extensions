using System;
using System.Linq;
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

        Task<(T1, T2, T3)> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(firstPipeAsync, secondPipeAsync, thirdPipeAsync, cancellationToken);
    }

    private static async Task<(T1, T2, T3)> InnerPipeParallelAsync<TIn, T1, T2, T3>(
        this TIn input,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync,
        CancellationToken cancellationToken)
    {
        T1 first = default!;
        T2 second = default!;
        T3 third = default!;

        await Parallel.ForEachAsync(
            source: Enumerable.Range(0, 3),
            cancellationToken: cancellationToken,
            body: InnerInvokeAsync);

        return (first, second, third);

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

                default:
                throw CreateIndexOutOfRangeException(index);
            };
        }
    }
}