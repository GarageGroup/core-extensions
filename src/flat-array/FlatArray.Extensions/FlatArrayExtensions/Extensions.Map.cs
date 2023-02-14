using System;

namespace GGroupp;

partial class FlatArrayExtensions
{
    public static FlatArray<TResult> Map<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, TResult> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (source.IsEmpty)
        {
            return default;
        }

        var builder = FlatArray<TResult>.Builder.OfLength(source.Length);

        for (var i = 0; i < source.Length; i++)
        {
            var sourceItem = source[i];
            builder[i] = map.Invoke(sourceItem);
        }

        return builder.MoveToFlatArray();
    }

    public static FlatArray<TResult> Map<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, int, TResult> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (source.IsEmpty)
        {
            return default;
        }

        var builder = FlatArray<TResult>.Builder.OfLength(source.Length);

        for (var i = 0; i < source.Length; i++)
        {
            builder[i] = map.Invoke(source[i], i);
        }

        return builder.MoveToFlatArray();
    }
}