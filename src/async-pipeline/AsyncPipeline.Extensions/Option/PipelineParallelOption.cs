namespace GarageGroup;

public sealed record class PipelineParallelOption
{
    public int? DegreeOfParallelism { get; init; }

    public PipelineParallelFailureAction FailureAction { get; init; }
}