using System.Collections.Generic;

namespace GarageGroup.Core.Collections.Test;

public static partial class AsyncPipelineExtensionsTest
{
    public static IEnumerable<object?[]> PipelineParallelOptionTestData
        =>
        new[]
        {
            new PipelineParallelOption?[]
            {
                null
            },
            new PipelineParallelOption?[]
            {
                new()
                {
                    DegreeOfParallelism = null,
                    FailureAction = PipelineParallelFailureAction.Stop
                }
            },
            new PipelineParallelOption?[]
            {
                new()
                {
                    DegreeOfParallelism = -1,
                    FailureAction = PipelineParallelFailureAction.Default
                }
            },
            new PipelineParallelOption?[]
            {
                new()
                {
                    DegreeOfParallelism = 0
                }
            },
            new PipelineParallelOption?[]
            {
                new()
                {
                    DegreeOfParallelism = 1
                }
            },
            new PipelineParallelOption?[]
            {
                new()
                {
                    DegreeOfParallelism = 5,
                    FailureAction = PipelineParallelFailureAction.Default
                }
            },
            new PipelineParallelOption?[]
            {
                new()
                {
                    DegreeOfParallelism = 5,
                    FailureAction = PipelineParallelFailureAction.Stop
                }
            }
        };
}