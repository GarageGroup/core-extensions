using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4)> PipeParallel<TIn, T1, T2, T3, T4>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<T4>> fourthPipeAsync)
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);

        return pipeline.InnerPipeParallel(
            firstPipeAsync,
            secondPipeAsync,
            thirdPipeAsync,
            fourthPipeAsync);
    }

    private static AsyncPipeline<(T1, T2, T3, T4)> InnerPipeParallel<TIn, T1, T2, T3, T4>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<T4>> fourthPipeAsync)
    {
        return pipeline.Pipe(InnerPipeAsync);

        Task<(T1, T2, T3, T4)> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(
                firstPipeAsync, secondPipeAsync, thirdPipeAsync, fourthPipeAsync, pipeline.Configuration, cancellationToken);
    }

    private static async Task<(T1, T2, T3, T4)> InnerPipeParallelAsync<TIn, T1, T2, T3, T4>(
        this TIn input,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<T4>> fourthPipeAsync,
        AsyncPipelineConfiguration configuration,
        CancellationToken cancellationToken)
    {
        T1 first = default!;
        T2 second = default!;
        T3 third = default!;
        T4 fourth = default!;

        var options = configuration.InnerCreateParallelOptions(null, cancellationToken);
        await Parallel.ForEachAsync(Enumerable.Range(0, 4), options, InnerInvokeAsync).ConfigureAwait(configuration.ContinueOnCapturedContext);

        return (first, second, third, fourth);

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

                case 2:
                third = await thirdPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(configuration.ContinueOnCapturedContext);
                break;

                case 3:
                fourth = await fourthPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(configuration.ContinueOnCapturedContext);
                break;

                default:
                throw CreateIndexOutOfRangeException(index);
            };
        }
    }
}