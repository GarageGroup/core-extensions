using Xunit;

namespace GarageGroup.Core.Collections.Test;

public static partial class AsyncPipelineExtensionsTest
{
    public static TheoryData<PipelineParallelOption?> PipelineParallelOptionTestData
        =>
        new()
        {
            {
                null
            },
            {
                new()
                {
                    DegreeOfParallelism = null,
                    FailureAction = PipelineParallelFailureAction.Stop
                }
            },
            {
                new()
                {
                    DegreeOfParallelism = -1,
                    FailureAction = PipelineParallelFailureAction.Default
                }
            },
            {
                new()
                {
                    DegreeOfParallelism = 0
                }
            },
            {
                new()
                {
                    DegreeOfParallelism = 1
                }
            },
            {
                new()
                {
                    DegreeOfParallelism = 5,
                    FailureAction = PipelineParallelFailureAction.Default
                }
            },
            {
                new()
                {
                    DegreeOfParallelism = 5,
                    FailureAction = PipelineParallelFailureAction.Stop
                }
            }
        };

    public static TheoryData<PipelineParallelOption?, int> PipelineParallelOptionTestDataWithCount(int count)
    {
        var data = new TheoryData<PipelineParallelOption?, int>();

        foreach (var option in PipelineParallelOptionTestData)
        {
            data.Add(option, count);
        }

        return data;
    }
}