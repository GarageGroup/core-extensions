using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<FlatArray<TOut>, TFailure> PipeParallel<TIn, TOut, TFailure>(
        this AsyncPipeline<FlatArray<TIn>> pipeline,
        Func<TIn, CancellationToken, Task<Result<TOut, TFailure>>> pipeAsync,
        PipelineParallelOption option = default)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(pipeAsync);

        return pipeline.PipeValue(InnerPipeAsync).Pipe(InnerJoinSuccess<TIn, TOut, TFailure>);

        ValueTask<FlatArray<Result<TOut, TFailure>>> InnerPipeAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(pipeAsync, option, cancellationToken);
    }

    private static Result<FlatArray<TOut>, TFailure> InnerJoinSuccess<TIn, TOut, TFailure>(
        FlatArray<Result<TOut, TFailure>> results)
        where TFailure : struct
    {
        var builder = FlatArray<TOut>.Builder.OfLength(results.Length);

        for (var i = 0; i < results.Length; i++)
        {
            var result = results[i];

            if (result.IsFailure)
            {
                return result.FailureOrThrow();
            }

            builder[i] = result.SuccessOrThrow();
        }

        return builder.MoveToFlatArray();
    }
}