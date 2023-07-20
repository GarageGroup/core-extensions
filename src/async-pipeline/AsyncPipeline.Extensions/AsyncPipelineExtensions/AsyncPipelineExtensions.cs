using System;
using System.Collections.Generic;

namespace GarageGroup;

public static partial class AsyncPipelineExtensions
{
    private static IEnumerable<T[]> SplitIntoChunks<T>(this T[] array, int chunkSize)
    {
        int numberOfChunks = array.Length / chunkSize;
        if (array.Length % chunkSize > 0)
        {
            numberOfChunks++;
        }

        for (int i = 0; i < numberOfChunks; i++)
        {
            int start = i * chunkSize;
            int length = chunkSize;

            if ((start + length) > array.Length)
            {
                length = array.Length - start;
            }

            var chunk = new T[length];
            Array.Copy(array, start, chunk, 0, length);

            yield return chunk;
        }
    }
}