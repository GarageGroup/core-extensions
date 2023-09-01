using System;
using System.Linq;
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

        Task<(T1, T2, T3, T4, T5, T6)> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(
                firstPipeAsync,
                secondPipeAsync,
                thirdPipeAsync,
                fourthPipeAsync,
                fifthPipeAsync,
                sixthPipeAsync,
                pipeline.Configuration,
                cancellationToken);
    }

    private static async Task<(T1, T2, T3, T4, T5, T6)> InnerPipeParallelAsync<TIn, T1, T2, T3, T4, T5, T6>(
        this TIn input,
        Func<TIn, CancellationToken, Task<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<T4>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<T5>> fifthPipeAsync,
        Func<TIn, CancellationToken, Task<T6>> sixthPipeAsync,
        AsyncPipelineConfiguration configuration,
        CancellationToken cancellationToken)
    {
        T1 first = default!;
        T2 second = default!;
        T3 third = default!;
        T4 fourth = default!;
        T5 fifth = default!;
        T6 sixth = default!;

        var options = configuration.InnerCreateParallelOptions(null, cancellationToken);
        await Parallel.ForEachAsync(Enumerable.Range(0, 6), options, InnerInvokeAsync).ConfigureAwait(configuration.ContinueOnCapturedContext);

        return (first, second, third, fourth, fifth, sixth);

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

                case 4:
                fifth = await fifthPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(configuration.ContinueOnCapturedContext);
                break;

                case 5:
                sixth = await sixthPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(configuration.ContinueOnCapturedContext);
                break;

                default:
                throw CreateIndexOutOfRangeException(index);
            };
        }
    }
}