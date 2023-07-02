using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TOtherSuccess, TFailure> RecoverValue<TSuccess, TFailure, TOtherSuccess>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, CancellationToken, ValueTask<Result<TOtherSuccess, TFailure>>> otherFactoryAsync,
        Func<TSuccess, CancellationToken, ValueTask<TOtherSuccess>> mapSuccessAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(otherFactoryAsync);
        ArgumentNullException.ThrowIfNull(mapSuccessAsync);

        return pipeline.PipeValue(InnerPipeAsync);

        ValueTask<Result<TOtherSuccess, TFailure>> InnerPipeAsync(Result<TSuccess, TFailure> current, CancellationToken cancellationToken)
            =>
            current.RecoverValueAsync(
                failure => otherFactoryAsync.Invoke(failure, cancellationToken),
                success => mapSuccessAsync.Invoke(success, cancellationToken));
    }

    public static AsyncPipeline<TSuccess, TOtherFailure> RecoverValue<TSuccess, TFailure, TOtherFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, CancellationToken, ValueTask<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
        where TFailure : struct
        where TOtherFailure : struct
    {
        ArgumentNullException.ThrowIfNull(otherFactoryAsync);

        return pipeline.PipeValue(InnerPipeAsync);

        ValueTask<Result<TSuccess, TOtherFailure>> InnerPipeAsync(Result<TSuccess, TFailure> current, CancellationToken cancellationToken)
            =>
            current.RecoverValueAsync(
                failure => otherFactoryAsync.Invoke(failure, cancellationToken));
    }

    public static AsyncPipeline<TOtherSuccess, TOtherFailure> RecoverValue<TSuccess, TFailure, TOtherSuccess, TOtherFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, CancellationToken, ValueTask<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
        Func<TSuccess, CancellationToken, ValueTask<TOtherSuccess>> mapSuccessAsync)
        where TFailure : struct
        where TOtherFailure : struct
    {
        ArgumentNullException.ThrowIfNull(otherFactoryAsync);
        ArgumentNullException.ThrowIfNull(mapSuccessAsync);

        return pipeline.PipeValue(InnerPipeAsync);

        ValueTask<Result<TOtherSuccess, TOtherFailure>> InnerPipeAsync(Result<TSuccess, TFailure> current, CancellationToken cancellationToken)
            =>
            current.RecoverValueAsync(
                failure => otherFactoryAsync.Invoke(failure, cancellationToken),
                success => mapSuccessAsync.Invoke(success, cancellationToken));
    }
}