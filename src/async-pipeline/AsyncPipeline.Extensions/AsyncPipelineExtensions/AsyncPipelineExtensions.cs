using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace GarageGroup;

public static partial class AsyncPipelineExtensions
{
    private static ParallelOptions InnerCreateParallelOptions(
        this AsyncPipelineConfiguration pipelineConfiguration,
        int? degreeOfParallelism,
        CancellationToken cancellationToken)
    {
        var options = new ParallelOptions
        {
            CancellationToken = cancellationToken,
        };

        if (pipelineConfiguration.ContinueOnCapturedContext)
        {
            options.TaskScheduler = GetTaskScheduler();
        }

        if (degreeOfParallelism > 0)
        {
            options.MaxDegreeOfParallelism = degreeOfParallelism.Value;
        }

        return options;
    }

    private sealed class InnerFailureException<TFailure> : Exception
        where TFailure : struct
    {
        public static InnerFailureException<TFailure> From(TFailure failure)
            =>
            new(failure);

        private InnerFailureException(TFailure failure)
            =>
            Failure = failure;

        public TFailure Failure { get; }
    }

    private static TaskScheduler GetTaskScheduler()
    {
        var context = SynchronizationContext.Current;

        if (context is null)
        {
            return TaskScheduler.FromCurrentSynchronizationContext();
        }

        return new InnerTaskScheduler(context);
    }

    private sealed class InnerTaskScheduler : TaskScheduler
    {
        private readonly SynchronizationContext context;

        internal InnerTaskScheduler(SynchronizationContext context)
            =>
            this.context = context;

        protected override void QueueTask(Task task)
        {
            context.Post(InnerTryExecute, task);

            void InnerTryExecute(object? source)
            {
                Debug.Assert(source is not null, "Source value must be not null");
                _ = TryExecuteTask((Task)source);
            }
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
            =>
            SynchronizationContext.Current == context && TryExecuteTask(task);

        protected override IEnumerable<Task>? GetScheduledTasks()
            =>
            null;
    }

    private static IndexOutOfRangeException CreateIndexOutOfRangeException(int index)
        =>
        new($"An unexpected index value: {index}");
}
