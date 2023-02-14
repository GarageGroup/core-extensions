using System;
using System.Threading;
using System.Threading.Tasks;

namespace GGroupp;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<T> OnValue<T>(
        this AsyncPipeline<T> pipeline,
        Func<T, CancellationToken, ValueTask> onAsync)
    {
        ArgumentNullException.ThrowIfNull(onAsync);
        return pipeline.PipeValue(InnerPipeAsync);

        async ValueTask<T> InnerPipeAsync(T current, CancellationToken cancellationToken)
        {
            await onAsync.Invoke(current, cancellationToken).ConfigureAwait(false);
            return current;
        }
    }

    public static AsyncPipeline<T> OnValue<T>(
        this AsyncPipeline<T> pipeline,
        Func<T, CancellationToken, ValueTask<Unit>> onAsync)
    {
        ArgumentNullException.ThrowIfNull(onAsync);
        return pipeline.PipeValue(InnerPipeAsync);

        async ValueTask<T> InnerPipeAsync(T current, CancellationToken cancellationToken)
        {
            _ = await onAsync.Invoke(current, cancellationToken).ConfigureAwait(false);
            return current;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnValue<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, CancellationToken, ValueTask> onSuccessAsync,
        Func<TFailure, CancellationToken, ValueTask> onFailureAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccessAsync);
        ArgumentNullException.ThrowIfNull(onFailureAsync);

        return pipeline.MapValue(InnerMapSuccessAsync, InnerMapFailureAsync);

        async ValueTask<TSuccess> InnerMapSuccessAsync(TSuccess success, CancellationToken cancellationToken)
        {
            await onSuccessAsync.Invoke(success, cancellationToken).ConfigureAwait(false);
            return success;
        }

        async ValueTask<TFailure> InnerMapFailureAsync(TFailure failure, CancellationToken cancellationToken)
        {
            await onFailureAsync.Invoke(failure, cancellationToken).ConfigureAwait(false);
            return failure;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnSuccessValue<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, CancellationToken, ValueTask> onSuccessAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccessAsync);
        return pipeline.MapSuccessValue(InnerMapSuccessAsync);

        async ValueTask<TSuccess> InnerMapSuccessAsync(TSuccess success, CancellationToken cancellationToken)
        {
            await onSuccessAsync.Invoke(success, cancellationToken).ConfigureAwait(false);
            return success;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnFailureValue<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, CancellationToken, ValueTask> onFailureAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onFailureAsync);
        return pipeline.MapFailureValue(InnerMapFailureAsync);

        async ValueTask<TFailure> InnerMapFailureAsync(TFailure failure, CancellationToken cancellationToken)
        {
            await onFailureAsync.Invoke(failure, cancellationToken).ConfigureAwait(false);
            return failure;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnValue<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, CancellationToken, ValueTask<Unit>> onSuccessAsync,
        Func<TFailure, CancellationToken, ValueTask<Unit>> onFailureAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccessAsync);
        ArgumentNullException.ThrowIfNull(onFailureAsync);

        return pipeline.MapValue(InnerMapSuccessAsync, InnerMapFailureAsync);

        async ValueTask<TSuccess> InnerMapSuccessAsync(TSuccess success, CancellationToken cancellationToken)
        {
            _ = await onSuccessAsync.Invoke(success, cancellationToken).ConfigureAwait(false);
            return success;
        }

        async ValueTask<TFailure> InnerMapFailureAsync(TFailure failure, CancellationToken cancellationToken)
        {
            _ = await onFailureAsync.Invoke(failure, cancellationToken).ConfigureAwait(false);
            return failure;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnSuccessValue<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, CancellationToken, ValueTask<Unit>> onSuccessAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccessAsync);
        return pipeline.MapSuccessValue(InnerMapSuccessAsync);

        async ValueTask<TSuccess> InnerMapSuccessAsync(TSuccess success, CancellationToken cancellationToken)
        {
            _ = await onSuccessAsync.Invoke(success, cancellationToken).ConfigureAwait(false);
            return success;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnFailureValue<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, CancellationToken, ValueTask<Unit>> onFailureAsync)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onFailureAsync);
        return pipeline.MapFailureValue(InnerMapFailureAsync);

        async ValueTask<TFailure> InnerMapFailureAsync(TFailure failure, CancellationToken cancellationToken)
        {
            _ = await onFailureAsync.Invoke(failure, cancellationToken).ConfigureAwait(false);
            return failure;
        }
    }
}