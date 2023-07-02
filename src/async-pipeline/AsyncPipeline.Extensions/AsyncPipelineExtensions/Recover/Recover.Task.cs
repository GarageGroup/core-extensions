using System;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<TOtherSuccess, TFailure> Recover<TSuccess, TFailure, TOtherSuccess>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, CancellationToken, Task<Result<TOtherSuccess, TFailure>>> otherFactoryAsync,
        Func<TSuccess, CancellationToken, Task<TOtherSuccess>> mapSuccessAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(otherFactoryAsync);
        ArgumentNullException.ThrowIfNull(mapSuccessAsync);

        return pipeline.Pipe(InnerPipeAsync);

        Task<Result<TOtherSuccess, TFailure>> InnerPipeAsync(Result<TSuccess, TFailure> current, CancellationToken cancellationToken)
            =>
            current.RecoverAsync(
                failure => otherFactoryAsync.Invoke(failure, cancellationToken),
                success => mapSuccessAsync.Invoke(success, cancellationToken));
    }

    public static AsyncPipeline<TSuccess, TOtherFailure> Recover<TSuccess, TFailure, TOtherFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, CancellationToken, Task<Result<TSuccess, TOtherFailure>>> otherFactoryAsync)
        where TFailure : struct
        where TOtherFailure : struct
    {
        ArgumentNullException.ThrowIfNull(otherFactoryAsync);

        return pipeline.Pipe(InnerPipeAsync);

        Task<Result<TSuccess, TOtherFailure>> InnerPipeAsync(Result<TSuccess, TFailure> current, CancellationToken cancellationToken)
            =>
            current.RecoverAsync(
                failure => otherFactoryAsync.Invoke(failure, cancellationToken));
    }

    public static AsyncPipeline<TOtherSuccess, TOtherFailure> Recover<TSuccess, TFailure, TOtherSuccess, TOtherFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, CancellationToken, Task<Result<TOtherSuccess, TOtherFailure>>> otherFactoryAsync,
        Func<TSuccess, CancellationToken, Task<TOtherSuccess>> mapSuccessAsync)
        where TFailure : struct
        where TOtherFailure : struct
    {
        ArgumentNullException.ThrowIfNull(otherFactoryAsync);
        ArgumentNullException.ThrowIfNull(mapSuccessAsync);

        return pipeline.Pipe(InnerPipeAsync);

        Task<Result<TOtherSuccess, TOtherFailure>> InnerPipeAsync(Result<TSuccess, TFailure> current, CancellationToken cancellationToken)
            =>
            current.RecoverAsync(
                failure => otherFactoryAsync.Invoke(failure, cancellationToken),
                success => mapSuccessAsync.Invoke(success, cancellationToken));
    }
}