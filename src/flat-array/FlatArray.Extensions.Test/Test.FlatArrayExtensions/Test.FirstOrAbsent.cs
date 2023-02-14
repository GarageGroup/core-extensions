using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GGroupp.Core.Collections.Test;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public static void FirstOrAbsent_SourceIsEmpty_ExpectAbsent()
    {
        var source = FlatArray<RefType>.Empty;

        var actual = source.FirstOrAbsent();
        var expected = Optional.Absent<RefType>();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(EmptyString)]
    [InlineData(AnotherString, EmptyString)]
    [InlineData(null, SomeString, AnotherString)]
    public static void FirstOrAbsent_SourceIsNotEmpty_ExpectFirstItem(params string?[] others)
    {
        var source = others.ToFlatArray();

        var actual = source.FirstOrAbsent();
        var expected = others[0];

        Assert.Equal(expected, actual);
    }
}