using System;

namespace GarageGroup;

public static partial class AsyncPipelineExtensions
{
    private static IndexOutOfRangeException CreateIndexOutOfRangeException(int index)
        =>
        new($"An unexpected index value: {index}");
}