using Xunit;

namespace GarageGroup.Core.Collections.Test;

public static partial class AsyncPipelineExtensionsTest
{
    public static TheoryData<PipelineParallelOption?> PipelineParallelOptionTestData
    {
        get
        {
            var data = new TheoryData<PipelineParallelOption?>();

            data.Add((PipelineParallelOption?)null);
            data.Add(
                (PipelineParallelOption?)new PipelineParallelOption
                {
                    DegreeOfParallelism = null,
                    FailureAction = PipelineParallelFailureAction.Stop
                });
            data.Add(
                (PipelineParallelOption?)new PipelineParallelOption
                {
                    DegreeOfParallelism = -1,
                    FailureAction = PipelineParallelFailureAction.Default
                });
            data.Add(
                (PipelineParallelOption?)new PipelineParallelOption
                {
                    DegreeOfParallelism = 0
                });
            data.Add(
                (PipelineParallelOption?)new PipelineParallelOption
                {
                    DegreeOfParallelism = 1
                });
            data.Add(
                (PipelineParallelOption?)new PipelineParallelOption
                {
                    DegreeOfParallelism = 5,
                    FailureAction = PipelineParallelFailureAction.Default
                });
            data.Add(
                (PipelineParallelOption?)new PipelineParallelOption
                {
                    DegreeOfParallelism = 5,
                    FailureAction = PipelineParallelFailureAction.Stop
                });

            return data;
        }
    }

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
