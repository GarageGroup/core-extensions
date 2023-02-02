using System;

namespace GGroupp;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TSuccess> SuccessOrThrow<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, Exception> exceptionFactory)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(exceptionFactory);
        return pipeline.Pipe(InnerPipe);

        TSuccess InnerPipe(Result<TSuccess, TFailure> current)
            =>
            current.SuccessOrThrow(exceptionFactory);
    }
}