namespace GarageGroup;

public readonly record struct PipelineParallelOption
{
    public int? DegreeOfParallelism { get; init; }
}