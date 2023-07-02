using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GarageGroup.Core.Collections.Test;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [InlineData]
    [InlineData(null, PlusFifteen, Zero, One)]
    public static void Concat_SourceIsEmpty_ExpectOther(params int?[] otherArray)
    {
        var source = default(FlatArray<int?>);
        var other = otherArray.ToFlatArray();

        var actual = source.Concat(other);
        var expected = other;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData]
    [InlineData(SomeString, null, AnotherString)]
    public static void Concat_OtherIsEmpty_ExpectSource(params string?[] sourceArray)
    {
        var source = sourceArray.ToFlatArray();
        var other = default(FlatArray<string?>);

        var actual = source.Concat(other);
        var expected = source;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public static void Concat_SourceAndOtherAreNotEmpty_ExpectMergedArray()
    {
        var source = new FlatArray<RefType?>(null, PlusFifteenIdRefType);
        var other = new FlatArray<RefType?>(MinusFifteenIdRefType, null, ZeroIdRefType);

        var actual = source.Concat(other);
        var expected = new FlatArray<RefType?>(null, PlusFifteenIdRefType, MinusFifteenIdRefType, null, ZeroIdRefType);

        Assert.Equal(expected, actual);
    }
}