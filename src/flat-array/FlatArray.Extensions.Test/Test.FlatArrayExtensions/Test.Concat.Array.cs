using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GGroupp.Core.Collections.Test;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [InlineData]
    [InlineData(SomeString, EmptyString)]
    public static void ConcatWithArray_SourceIsEmpty_ExpectOther(params string[] other)
    {
        var source = default(FlatArray<string>);

        var actual = source.Concat(other);
        var expected = other.ToFlatArray();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData]
    [InlineData(null, true)]
    public static void ConcatWithArray_OtherIsNull_ExpectSource(params bool?[] sourceArray)
    {
        var source = sourceArray.ToFlatArray();
        bool?[] other = null!;

        var actual = source.Concat(other);
        var expected = source;

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData]
    [InlineData(PlusFifteen, One, MinusOne, null, int.MaxValue)]
    public static void ConcatWithArray_OtherIsEmpty_ExpectSource(params int?[] sourceArray)
    {
        var source = sourceArray.ToFlatArray();
        var other = Array.Empty<int?>();

        var actual = source.Concat(other);
        var expected = source;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public static void ConcatWithArray_SourceAndOtherAreNotEmpty_ExpectMergedArray()
    {
        var source = new FlatArray<RecordStruct?>(SomeTextRecordStruct, AnotherTextRecordStruct);
        var other = new RecordStruct?[] { UpperAnotherTextRecordStruct, null };

        var actual = source.Concat(other);
        var expected = new FlatArray<RecordStruct?>(SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct, null);

        Assert.Equal(expected, actual);
    }
}