using System;
using System.Collections.Generic;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GarageGroup.Core.Collections.Test;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public static void FlatMapWithIndex_MapArgumentIsNull_ExpectArgumentNullException(bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new FlatArray<long>(long.MinValue, long.MaxValue);
        Func<long, int, FlatArray<object>> map = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.FlatMap(map);
    }

    [Fact]
    public static void FlatMapWithIndex_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<StructType>);
        var actual = source.FlatMap(Map);

        var expected = default(FlatArray<RecordStruct?>);
        Assert.Equal(expected, actual);

        static FlatArray<RecordStruct?> Map(StructType _, int index)
            =>
            new(null, SomeTextRecordStruct, AnotherTextRecordStruct);
    }

    [Fact]
    public static void FlatMapWithIndex_SourceIsNotDefault_ExpectMappedValues()
    {
        StructType? nullItem = null;

        var mapper = new Dictionary<string, FlatArray<StructType?>>
        {
            [SomeString] = default,
            [AnotherString] = new(SomeTextStructType, nullItem, AnotherTextStructType),
            [WhiteSpaceString] = new(nullItem)
        };

        var source = new FlatArray<string>(mapper.Keys.ToArray());
        var actual = source.FlatMap(Map);

        var expected = new FlatArray<StructType?>(SomeTextStructType, nullItem, AnotherTextStructType, nullItem);
        Assert.Equal(expected, actual);

        FlatArray<StructType?> Map(string sourceValue, int index)
        {
            Assert.Equal(source[index], sourceValue);
            return mapper[sourceValue];
        }
    }
}