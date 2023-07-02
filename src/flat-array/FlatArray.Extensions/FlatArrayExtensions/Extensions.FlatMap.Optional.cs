using System;
using System.Collections.Generic;

namespace GarageGroup;

partial class FlatArrayExtensions
{
    public static FlatArray<TResult> FlatMap<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, Optional<TResult>> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (source.IsEmpty)
        {
            return default;
        }

        var list = new List<TResult>(source.Length);

        for (var i = 0; i < source.Length; i++)
        {
            var item = source[i];
            map.Invoke(item).OnPresent(list.Add);
        }

        return list;
    }

    public static FlatArray<TResult> FlatMap<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, int, Optional<TResult>> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (source.IsEmpty)
        {
            return default;
        }

        var list = new List<TResult>(source.Length);

        for (var i = 0; i < source.Length; i++)
        {
            map.Invoke(source[i], i).OnPresent(list.Add);
        }

        return list;
    }
}