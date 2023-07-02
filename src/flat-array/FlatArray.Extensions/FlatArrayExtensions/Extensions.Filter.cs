using System;
using System.Collections.Generic;

namespace GarageGroup;

partial class FlatArrayExtensions
{
    public static FlatArray<T> Filter<T>(this FlatArray<T> array, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (array.IsEmpty)
        {
            return default;
        }

        var list = new List<T>(array.Length);

        for (var i = 0; i < array.Length; i++)
        {
            var item = array[i];

            if (predicate.Invoke(item) is false)
            {
                continue;
            }

            list.Add(item);
        }

        return list;
    }
}