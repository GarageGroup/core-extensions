using System;
using System.Collections.Generic;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GGroupp.Core.Collections.Test;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public static void FlatMap_MapArgumentIsNull_ExpectArgumentNullException(bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new FlatArray<RefType>(MinusFifteenIdRefType, ZeroIdRefType);
        Func<RefType, FlatArray<StructType>> map = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.FlatMap(map);
    }

    [Fact]
    public static void FlatMap_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<RecordStruct?>);
        var actual = source.FlatMap(Map);

        var expected = default(FlatArray<string>);
        Assert.Equal(expected, actual);

        static FlatArray<string> Map(RecordStruct? _)
            =>
            new(SomeString, AnotherString);
    }

    [Fact]
    public static void FlatMap_SourceIsNotDefault_ExpectMappedValues()
    {
        RecordType? nullItem = null;

        var mapper = new Dictionary<int, FlatArray<RecordType?>>
        {
            [MinusFifteen] = new(nullItem),
            [One] = default,
            [int.MaxValue] = new(PlusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord)
        };

        var source = new FlatArray<int>(mapper.Keys.ToArray());
        var actual = source.FlatMap(Map);

        var expected = new FlatArray<RecordType?>(nullItem, PlusFifteenIdSomeStringNameRecord, ZeroIdNullNameRecord);
        Assert.Equal(expected, actual);

        FlatArray<RecordType?> Map(int sourceValue)
            =>
            mapper[sourceValue];
    }
}