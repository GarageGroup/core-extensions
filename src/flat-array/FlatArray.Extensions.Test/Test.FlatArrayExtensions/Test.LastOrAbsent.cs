using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GarageGroup.Core.Collections.Test;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public static void LastOrAbsent_SourceIsEmpty_ExpectAbsent()
    {
        var source = FlatArray<RecordType?>.Empty;

        var actual = source.LastOrAbsent();
        var expected = Optional.Absent<RecordType?>();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(Zero)]
    [InlineData(MinusFifteen, One)]
    [InlineData(null, MinusFifteen, Zero, PlusFifteen)]
    public static void LastOrAbsent_SourceIsNotEmpty_ExpectLastItem(params int?[] others)
    {
        var source = others.ToFlatArray();

        var actual = source.LastOrAbsent();
        var expected = others[^1];

        Assert.Equal(expected, actual);
    }
}