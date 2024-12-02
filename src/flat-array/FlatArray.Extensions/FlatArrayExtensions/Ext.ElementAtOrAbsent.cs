using System;

namespace GarageGroup;

partial class FlatArrayExtensions
{
    public static Optional<T> ElementAtOrAbsent<T>(this FlatArray<T> array, int index)
        =>
        index >= 0 && index < array.Length ? Optional.Present(array[index]) : default;
}