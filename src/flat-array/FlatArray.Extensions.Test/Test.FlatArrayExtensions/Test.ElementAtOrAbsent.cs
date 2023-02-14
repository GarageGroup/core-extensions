using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GGroupp.Core.Collections.Test;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [InlineData(MinusOne)]
    [InlineData(Zero)]
    [InlineData(PlusFifteen)]
    public static void ElementAtOrAbsent_SourceIsEmpty_ExpectAbsent(int index)
    {
        var source = FlatArray<StructType?>.Empty;

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional.Absent<StructType?>();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(-1, SomeString)]
    [InlineData(3, AnotherString, LowerAnotherString, UpperSomeString)]
    public static void ElementAtOrAbsent_IndexIsOutOfRange_ExpectAbsent(int index, params string?[] items)
    {
        var source = FlatArray<string?>.From(items);

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional.Absent<string?>();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, EmptyString)]
    [InlineData(2, SomeString, WhiteSpaceString, null, AnotherString)]
    public static void ElementAtOrAbsent_IndexIsInRange_ExpectPresentItemByIndex(int index, params string?[] items)
    {
        var source = FlatArray<string?>.From(items);

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional.Present(items[index]);

        Assert.Equal(expected, actual);
    }
}