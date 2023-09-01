using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<(T1, T2, T3, T4, T5, T6, T7)> PipeParallelValue<TIn, T1, T2, T3, T4, T5, T6, T7>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, ValueTask<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T4>> fourthPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T5>> fifthPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T6>> sixthPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T7>> seventhPipeAsync)
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fifthPipeAsync);
        ArgumentNullException.ThrowIfNull(sixthPipeAsync);
        ArgumentNullException.ThrowIfNull(seventhPipeAsync);

        return pipeline.InnerPipeParallelValue(
            firstPipeAsync,
            secondPipeAsync,
            thirdPipeAsync,
            fourthPipeAsync,
            fifthPipeAsync,
            sixthPipeAsync,
            seventhPipeAsync);
    }

    private static AsyncPipeline<(T1, T2, T3, T4, T5, T6, T7)> InnerPipeParallelValue<TIn, T1, T2, T3, T4, T5, T6, T7>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, ValueTask<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T4>> fourthPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T5>> fifthPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T6>> sixthPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T7>> seventhPipeAsync)
    {
        return pipeline.PipeValue(InnerPipeAsync);

        ValueTask<(T1, T2, T3, T4, T5, T6, T7)> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelValueAsync(
                firstPipeAsync,
                secondPipeAsync,
                thirdPipeAsync,
                fourthPipeAsync,
                fifthPipeAsync,
                sixthPipeAsync,
                seventhPipeAsync,
                pipeline.Configuration,
                cancellationToken);
    }

    private static async ValueTask<(T1, T2, T3, T4, T5, T6, T7)> InnerPipeParallelValueAsync<TIn, T1, T2, T3, T4, T5, T6, T7>(
        this TIn input,
        Func<TIn, CancellationToken, ValueTask<T1>> firstPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T2>> secondPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T3>> thirdPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T4>> fourthPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T5>> fifthPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T6>> sixthPipeAsync,
        Func<TIn, CancellationToken, ValueTask<T7>> seventhPipeAsync,
        AsyncPipelineConfiguration configuration,
        CancellationToken cancellationToken)
    {
        T1 first = default!;
        T2 second = default!;
        T3 third = default!;
        T4 fourth = default!;
        T5 fifth = default!;
        T6 sixth = default!;
        T7 seventh = default!;

        var options = configuration.InnerCreateParallelOptions(null, cancellationToken);
        await Parallel.ForEachAsync(Enumerable.Range(0, 7), options, InnerInvokeAsync).ConfigureAwait(configuration.ContinueOnCapturedContext);

        return (first, second, third, fourth, fifth, sixth, seventh);

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

                case 6:
                seventh = await seventhPipeAsync.Invoke(input, cancellationToken).ConfigureAwait(configuration.ContinueOnCapturedContext);
                break;

                default:
                throw CreateIndexOutOfRangeException(index);
            };
        }
    }
}