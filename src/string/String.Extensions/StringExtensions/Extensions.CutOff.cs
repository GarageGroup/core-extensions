using System;
using System.Diagnostics.CodeAnalysis;

namespace GGroupp;

partial class StringExtensions
{
    [return: NotNullIfNotNull(nameof(source))]
    public static string? CutOff(this string? source, int maxLength)
    {
        if (maxLength < 0)
        {
            throw new ArgumentOutOfRangeException(
                paramName: nameof(maxLength),
                actualValue: maxLength,
                message: "The max length must not be negative");
        }

        if (string.IsNullOrEmpty(source) || source.Length <= maxLength)
        {
            return source;
        }

        return source[..maxLength];
    }
}