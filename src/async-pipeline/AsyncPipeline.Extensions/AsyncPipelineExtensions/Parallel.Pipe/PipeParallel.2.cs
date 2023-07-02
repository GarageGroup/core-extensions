using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TNext> PipeParallel<TIn, TOut1, TOut2, TNext>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<TOut1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<TOut2>> secondPipeAsync,
        Func<TOut1, TOut2, TNext> fold)
    {
        ArgumentNullException.ThrowIfNull(firstPipeAsync);
        ArgumentNullException.ThrowIfNull(secondPipeAsync);
        ArgumentNullException.ThrowIfNull(fold);

        return pipeline.InnerPipeParallel(firstPipeAsync, secondPipeAsync, fold);
    }

    private static AsyncPipeline<TNext> InnerPipeParallel<TIn, TOut1, TOut2, TNext>(
        this AsyncPipeline<TIn> pipeline,
        Func<TIn, CancellationToken, Task<TOut1>> firstPipeAsync,
        Func<TIn, CancellationToken, Task<TOut2>> secondPipeAsync,
        Func<TOut1, TOut2, TNext> fold)
    {
        return pipeline.Pipe(InnerPipeAsync);

        async Task<TNext> InnerPipeAsync(TIn input, CancellationToken cancellationToken)
        {
            var firstTask = firstPipeAsync.Invoke(input, cancellationToken);
            var secondTask = secondPipeAsync.Invoke(input, cancellationToken);

            await Task.WhenAll(firstTask, secondTask).ConfigureAwait(false);
            return fold.Invoke(firstTask.Result, secondTask.Result);
        }
    }
}