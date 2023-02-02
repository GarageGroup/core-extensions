using System;

namespace GGroupp;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TFailure> FailureOrThrow<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, Exception> exceptionFactory)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(exceptionFactory);
        return pipeline.Pipe(InnerPipe);

        TFailure InnerPipe(Result<TSuccess, TFailure> current)
            =>
            current.FailureOrThrow(exceptionFactory);
    }
}