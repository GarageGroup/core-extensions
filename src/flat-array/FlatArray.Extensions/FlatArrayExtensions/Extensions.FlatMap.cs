using System;
using System.Collections.Generic;

namespace GGroupp;

partial class FlatArrayExtensions
{
    public static FlatArray<TResult> FlatMap<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, FlatArray<TResult>> map)
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
            var items = map.Invoke(item);

            if (items.IsEmpty)
            {
                continue;
            }

            list.AddRange(items.AsEnumerable());
        }

        return list;
    }

    public static FlatArray<TResult> FlatMap<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, int, FlatArray<TResult>> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (source.IsEmpty)
        {
            return default;
        }

        var list = new List<TResult>(source.Length);

        for (var i = 0; i < source.Length; i++)
        {
            var items = map.Invoke(source[i], i);

            if (items.IsEmpty)
            {
                continue;
            }

            list.AddRange(items.AsEnumerable());
        }

        return list;
    }
}