using System;
using Xunit;

namespace GarageGroup.Core.String.Extensions.Test;

partial class StringExtensionsTest
{
    [Theory]
    [InlineData(null, -1)]
    [InlineData(Strings.Empty, -3)]
    [InlineData("Some string", int.MinValue)]
    public static void CutOff_MaxLengthIsNegative_ExpectArgumentOutOfRangeException(
        string? source, int maxLength)
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(Test);

        Assert.Equal("maxLength", ex.ParamName);
        Assert.Equal(maxLength, ex.ActualValue);

        void Test()
            =>
            _ = source.CutOff(maxLength);
    }

    [Theory]
    [InlineData(null, 0, null)]
    [InlineData(null, 1, null)]
    [InlineData(Strings.Empty, 0, Strings.Empty)]
    [InlineData(Strings.Empty, 3, Strings.Empty)]
    [InlineData("Some string", 0, Strings.Empty)]
    [InlineData("Some string", 5, "Some ")]
    [InlineData("Some string", 11, "Some string")]
    [InlineData("Some string", 15, "Some string")]
    public static void CutOff_MaxLengthIsNotNegative_ExpectCorrectValue(
        string? source, int maxLength, string? expected)
    {
        var actual = source.CutOff(maxLength);
        Assert.Equal(expected, actual);
    }
}