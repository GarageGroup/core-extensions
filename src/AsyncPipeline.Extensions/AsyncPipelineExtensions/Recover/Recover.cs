using System;

namespace GGroupp;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TSuccess, TFailure> Recover<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, Result<TSuccess, TFailure>> otherFactory)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(otherFactory);

        return pipeline.Pipe(InnerPipe);

        Result<TSuccess, TFailure> InnerPipe(Result<TSuccess, TFailure> current)
            =>
            current.Recover(otherFactory);
    }

    public static AsyncPipeline<TOtherSuccess, TFailure> Recover<TSuccess, TFailure, TOtherSuccess>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, Result<TOtherSuccess, TFailure>> otherFactory,
        Func<TSuccess, TOtherSuccess> mapSuccess)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(otherFactory);
        ArgumentNullException.ThrowIfNull(mapSuccess);

        return pipeline.Pipe(InnerPipe);

        Result<TOtherSuccess, TFailure> InnerPipe(Result<TSuccess, TFailure> current)
            =>
            current.Recover(otherFactory, mapSuccess);
    }

    public static AsyncPipeline<TSuccess, TOtherFailure> Recover<TSuccess, TFailure, TOtherFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, Result<TSuccess, TOtherFailure>> otherFactory)
        where TFailure : struct
        where TOtherFailure : struct
    {
        ArgumentNullException.ThrowIfNull(otherFactory);

        return pipeline.Pipe(InnerPipe);

        Result<TSuccess, TOtherFailure> InnerPipe(Result<TSuccess, TFailure> current)
            =>
            current.Recover(otherFactory);
    }

    public static AsyncPipeline<TOtherSuccess, TOtherFailure> Recover<TSuccess, TFailure, TOtherSuccess, TOtherFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, Result<TOtherSuccess, TOtherFailure>> otherFactory,
        Func<TSuccess, TOtherSuccess> mapSuccess)
        where TFailure : struct
        where TOtherFailure : struct
    {
        ArgumentNullException.ThrowIfNull(otherFactory);
        ArgumentNullException.ThrowIfNull(mapSuccess);

        return pipeline.Pipe(InnerPipe);

        Result<TOtherSuccess, TOtherFailure> InnerPipe(Result<TSuccess, TFailure> current)
            =>
            current.Recover(otherFactory, mapSuccess);
    }
}