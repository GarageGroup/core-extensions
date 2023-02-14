using System;

namespace GGroupp;

partial class FlatArrayExtensions
{
    public static Optional<T> FirstOrAbsent<T>(this FlatArray<T> array)
        =>
        array.IsEmpty ? default : Optional.Present(array[0]);

    public static Optional<T> FirstOrAbsent<T>(this FlatArray<T> array, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (array.IsEmpty)
        {
            return default;
        }

        for (var i = 0; i < array.Length; i++)
        {
            var item = array[i];

            if (predicate.Invoke(item) is false)
            {
                continue;
            }

            return item;
        }

        return default;
    }
}