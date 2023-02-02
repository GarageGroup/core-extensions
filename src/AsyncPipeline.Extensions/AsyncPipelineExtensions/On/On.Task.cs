using System;
using System.Threading;
using System.Threading.Tasks;

namespace GGroupp;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<T> On<T>(
        this AsyncPipeline<T> pipeline,
        Func<T, CancellationToken, Task> onAsync)
    {
        ArgumentNullException.ThrowIfNull(onAsync);
        return pipeline.Pipe(InnerPipeAsync);

        async Task<T> InnerPipeAsync(T current, CancellationToken cancellationToken)
        {
            await onAsync.Invoke(current, cancellationToken).ConfigureAwait(false);
            return current;
        }
    }

    public static AsyncPipeline<T> On<T>(
        this AsyncPipeline<T> pipeline,
        Func<T, CancellationToken, Task<Unit>> onAsync)
    {
        ArgumentNullException.ThrowIfNull(onAsync);
        return pipeline.Pipe(InnerPipeAsync);

        async Task<T> InnerPipeAsync(T current, CancellationToken cancellationToken)
        {
            _ = await onAsync.Invoke(current, cancellationToken).ConfigureAwait(false);
            return current;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> On<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, CancellationToken, Task> onSuccessAsync,
        Func<TFailure, CancellationToken, Task> onFailureAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccessAsync);
        ArgumentNullException.ThrowIfNull(onFailureAsync);

        return pipeline.Map(InnerMapSuccessAsync, InnerMapFailureAsync);

        async Task<TSuccess> InnerMapSuccessAsync(TSuccess success, CancellationToken cancellationToken)
        {
            await onSuccessAsync.Invoke(success, cancellationToken).ConfigureAwait(false);
            return success;
        }

        async Task<TFailure> InnerMapFailureAsync(TFailure failure, CancellationToken cancellationToken)
        {
            await onFailureAsync.Invoke(failure, cancellationToken).ConfigureAwait(false);
            return failure;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnSuccess<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, CancellationToken, Task> onSuccessAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccessAsync);
        return pipeline.MapSuccess(InnerMapSuccessAsync);

        async Task<TSuccess> InnerMapSuccessAsync(TSuccess success, CancellationToken cancellationToken)
        {
            await onSuccessAsync.Invoke(success, cancellationToken).ConfigureAwait(false);
            return success;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnFailure<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, CancellationToken, Task> onFailureAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onFailureAsync);
        return pipeline.MapFailure(InnerMapFailureAsync);

        async Task<TFailure> InnerMapFailureAsync(TFailure failure, CancellationToken cancellationToken)
        {
            await onFailureAsync.Invoke(failure, cancellationToken).ConfigureAwait(false);
            return failure;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> On<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, CancellationToken, Task<Unit>> onSuccessAsync,
        Func<TFailure, CancellationToken, Task<Unit>> onFailureAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccessAsync);
        ArgumentNullException.ThrowIfNull(onFailureAsync);

        return pipeline.Map(InnerMapSuccessAsync, InnerMapFailureAsync);

        async Task<TSuccess> InnerMapSuccessAsync(TSuccess success, CancellationToken cancellationToken)
        {
            _ = await onSuccessAsync.Invoke(success, cancellationToken).ConfigureAwait(false);
            return success;
        }

        async Task<TFailure> InnerMapFailureAsync(TFailure failure, CancellationToken cancellationToken)
        {
            _ = await onFailureAsync.Invoke(failure, cancellationToken).ConfigureAwait(false);
            return failure;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnSuccess<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, CancellationToken, Task<Unit>> onSuccessAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccessAsync);
        return pipeline.MapSuccess(InnerMapSuccessAsync);

        async Task<TSuccess> InnerMapSuccessAsync(TSuccess success, CancellationToken cancellationToken)
        {
            _ = await onSuccessAsync.Invoke(success, cancellationToken).ConfigureAwait(false);
            return success;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnFailure<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, CancellationToken, Task<Unit>> onFailureAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onFailureAsync);
        return pipeline.MapFailure(InnerMapFailureAsync);

        async Task<TFailure> InnerMapFailureAsync(TFailure failure, CancellationToken cancellationToken)
        {
            _ = await onFailureAsync.Invoke(failure, cancellationToken).ConfigureAwait(false);
            return failure;
        }
    }
}