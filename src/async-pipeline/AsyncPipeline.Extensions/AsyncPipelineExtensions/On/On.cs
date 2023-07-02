using System;

namespace GarageGroup;

partial class AsyncPipelineExtensions
{
    public static AsyncPipeline<T> On<T>(
        this AsyncPipeline<T> pipeline,
        Action<T> on)
    {
        ArgumentNullException.ThrowIfNull(on);
        return pipeline.Pipe(InnerPipe);

        T InnerPipe(T current)
        {
            on.Invoke(current);
            return current;
        }
    }

    public static AsyncPipeline<T> On<T>(
        this AsyncPipeline<T> pipeline,
        Func<T, Unit> on)
    {
        ArgumentNullException.ThrowIfNull(on);
        return pipeline.Pipe(InnerPipe);

        T InnerPipe(T current)
        {
            _ = on.Invoke(current);
            return current;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> On<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Action<TSuccess> onSuccess,
        Action<TFailure> onFailure)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        return pipeline.Map(InnerMapSuccess, InnerMapFailure);

        TSuccess InnerMapSuccess(TSuccess success)
        {
            onSuccess.Invoke(success);
            return success;
        }

        TFailure InnerMapFailure(TFailure failure)
        {
            onFailure.Invoke(failure);
            return failure;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnSuccess<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Action<TSuccess> onSuccess)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccess);

        return pipeline.MapSuccess(InnerMapSuccess);

        TSuccess InnerMapSuccess(TSuccess success)
        {
            onSuccess.Invoke(success);
            return success;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnFailure<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Action<TFailure> onFailure)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onFailure);

        return pipeline.MapFailure(InnerMapFailure);

        TFailure InnerMapFailure(TFailure failure)
        {
            onFailure.Invoke(failure);
            return failure;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> On<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, Unit> onSuccess,
        Func<TFailure, Unit> onFailure)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccess);
        ArgumentNullException.ThrowIfNull(onFailure);

        return pipeline.Pipe(InnerPipe);

        Result<TSuccess, TFailure> InnerPipe(Result<TSuccess, TFailure> current)
        {
            _ = current.Map(onSuccess, onFailure);
            return current;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnSuccess<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TSuccess, Unit> onSuccess)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onSuccess);

        return pipeline.Pipe(InnerPipe);

        Result<TSuccess, TFailure> InnerPipe(Result<TSuccess, TFailure> current)
        {
            _ = current.MapSuccess(onSuccess);
            return current;
        }
    }

    public static AsyncPipeline<TSuccess, TFailure> OnFailure<TSuccess, TFailure>(
        this AsyncPipeline<TSuccess, TFailure> pipeline,
        Func<TFailure, Unit> onFailure)
        where TFailure : struct
    {
        ArgumentNullException.ThrowIfNull(onFailure);

        return pipeline.Pipe(InnerPipe);

        Result<TSuccess, TFailure> InnerPipe(Result<TSuccess, TFailure> current)
        {
            _ = current.MapFailure(onFailure);
            return current;
        }
    }
}