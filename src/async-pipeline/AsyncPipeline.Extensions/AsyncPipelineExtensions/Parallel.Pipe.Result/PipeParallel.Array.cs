using System;
using System.Linq;
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

        return pipeline.PipeValue(InnerPipeAsync);

        ValueTask<Result<FlatArray<TOut>, TFailure>> InnerPipeAsync(FlatArray<TIn> input, CancellationToken cancellationToken)
            =>
            input.InnerPipeParallelAsync(pipeAsync, option, cancellationToken);
    }

    private static async ValueTask<Result<FlatArray<TOut>, TFailure>> InnerPipeParallelAsync<TIn, TOut, TFailure>(
        this FlatArray<TIn> input,
        Func<TIn, CancellationToken, Task<Result<TOut, TFailure>>> pipeAsync,
        PipelineParallelOption option,
        CancellationToken cancellationToken)
        where TFailure : struct
    {
        if (input.IsEmpty)
        {
            return Result.Success<FlatArray<TOut>>(default);
        }

        var builder = FlatArray<TOut>.Builder.OfLength(input.Length);

        if (option.DegreeOfParallelism is not > 0)
        {
            var results = await Task.WhenAll(input.AsEnumerable().Select(InnerPipeAsync)).ConfigureAwait(false);

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

        if (option.DegreeOfParallelism is 1)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var result = await pipeAsync.Invoke(input[i], cancellationToken).ConfigureAwait(false);

                if (result.IsFailure)
                {
                    return result.FailureOrThrow();
                }

                builder[i] = result.SuccessOrThrow();
            }

            return builder.MoveToFlatArray();
        }

        var index = 0;

        foreach (var chunk in input.ToArray().SplitIntoChunks(option.DegreeOfParallelism.Value))
        {
            var results = await Task.WhenAll(chunk.Select(InnerPipeAsync)).ConfigureAwait(false);

            foreach (var result in results)
            {
                if (result.IsFailure)
                {
                    return result.FailureOrThrow();
                }

                builder[index] = result.SuccessOrThrow();
                index++;
            }
        }

        return builder.MoveToFlatArray();

        Task<Result<TOut, TFailure>> InnerPipeAsync(TIn @in)
            =>
            pipeAsync.Invoke(@in, cancellationToken);
    }
}