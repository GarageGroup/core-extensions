using System;

namespace GarageGroup;

partial class FlatArrayExtensions
{
    public static FlatArray<T> Concat<T>(this FlatArray<T> source, FlatArray<T> other)
    {
        if (source.IsEmpty)
        {
            return other;
        }

        if (other.IsEmpty)
        {
            return source;
        }

        var builder = FlatArray<T>.Builder.OfLength(source.Length + other.Length);

        for (var i = 0; i < source.Length; i++)
        {
            builder[i] = source[i];
        }

        for (var i = 0; i < other.Length; i++)
        {
            builder[source.Length + i] = other[i];
        }

        return builder.MoveToFlatArray();
    }

    public static FlatArray<T> Concat<T>(this FlatArray<T> source, params T[] other)
    {
        if (source.IsEmpty)
        {
            return other;
        }

        if (other?.Length is not > 0)
        {
            return source;
        }

        var result = new T[source.Length + other.Length];

        for (var i = 0; i < source.Length; i++)
        {
            result[i] = source[i];
        }

        for (var i = 0; i < other.Length; i++)
        {
            result[source.Length + i] = other[i];
        }

        return result;
    }
}