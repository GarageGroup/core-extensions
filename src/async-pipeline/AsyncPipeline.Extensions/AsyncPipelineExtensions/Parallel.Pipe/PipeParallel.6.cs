using System;
using System.Threading;
using System.Threading.Tasks;

namespace GGroupp;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TNext> PipeParallel<TIn, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TNext>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<TOut1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<TOut2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<TOut3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<TOut4>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<TOut5>> fifthPipeAsync,
        Func<TIn, CancellationToken, Task<TOut6>> sixthPipeAsync,
        Func<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TNext> fold)
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(thirdPipeAsync);
        ArgumentNullException.ThrowIfNull(fourthPipeAsync);
        ArgumentNullException.ThrowIfNull(fifthPipeAsync);
        ArgumentNullException.ThrowIfNull(sixthPipeAsync);
        ArgumentNullException.ThrowIfNull(fold);

        return pipeline.InnerPipeParallel(
            firstPipeAsync,
            secondPipeAsync,
            thirdPipeAsync,
            fourthPipeAsync,
            fifthPipeAsync,
            sixthPipeAsync,
            fold);
    }

    private static AsyncPipeline<TNext> InnerPipeParallel<TIn, TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TNext>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<TOut1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<TOut2>> secondPipeAsync,
        Func<TIn, CancellationToken, Task<TOut3>> thirdPipeAsync,
        Func<TIn, CancellationToken, Task<TOut4>> fourthPipeAsync,
        Func<TIn, CancellationToken, Task<TOut5>> fifthPipeAsync,
        Func<TIn, CancellationToken, Task<TOut6>> sixthPipeAsync,
        Func<TOut1, TOut2, TOut3, TOut4, TOut5, TOut6, TNext> fold)
    {
        return pipeline.Pipe(InnerPipeAsync);

        async Task<TNext> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
        {
            var firstTask = firstPipeAsync.Invoke(input, cancellationToken);
            var secondTask = secondPipeAsync.Invoke(input, cancellationToken);
            var thirdTask = thirdPipeAsync.Invoke(input, cancellationToken);
            var fourthTask = fourthPipeAsync.Invoke(input, cancellationToken);
            var fifthTask = fifthPipeAsync.Invoke(input, cancellationToken);
            var sixthTask = sixthPipeAsync.Invoke(input, cancellationToken);

            await Task.WhenAll(firstTask, secondTask, thirdTask, fourthTask, fifthTask, sixthTask).ConfigureAwait(false);

            return fold.Invoke(
                firstTask.Result,
                secondTask.Result,
                thirdTask.Result,
                fourthTask.Result,
                fifthTask.Result,
                sixthTask.Result);
        }
    }
}