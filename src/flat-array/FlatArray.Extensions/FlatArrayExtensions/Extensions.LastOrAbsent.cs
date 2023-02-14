using System;

namespace GGroupp;

partial class FlatArrayExtensions
{
    public static Optional<T> LastOrAbsent<T>(this FlatArray<T> array)
        =>
        array.IsEmpty ? default : Optional.Present(array[^1]);

    public static Optional<T> LastOrAbsent<T>(this FlatArray<T> array, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (array.IsEmpty)
        {
            return default;
        }

        for (var i = 1; i <= array.Length; i++)
        {
            var item = array[^i];

            if (predicate.Invoke(item) is false)
            {
                continue;
            }

            return item;
        }

        return default;
    }
}