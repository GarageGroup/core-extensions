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

        return InnerGetItems().ToFlatArray();

        IEnumerable<TResult> InnerGetItems()
        {
            for (var i = 0; i < source.Length; i++)
            {
                var item = map.Invoke(source[i]);
                if (item.IsPresent)
                {
                    yield return item.OrThrow();
                }
            }
        }
    }

    public static FlatArray<TResult> FlatMap<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, int, Optional<TResult>> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (source.IsEmpty)
        {
            return default;
        }

        return InnerGetItems().ToFlatArray();

        IEnumerable<TResult> InnerGetItems()
        {
            for (var i = 0; i < source.Length; i++)
            {
                var item = map.Invoke(source[i], i);
                if (item.IsPresent)
                {
                    yield return item.OrThrow();
                }
            }
        }
    }
}