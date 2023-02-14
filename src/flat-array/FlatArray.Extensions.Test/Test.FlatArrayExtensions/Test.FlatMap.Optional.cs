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
    public static void FlatMapWithOptional_MapArgumentIsNull_ExpectArgumentNullException(bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new FlatArray<RecordType>(MinusFifteenIdSomeStringNameRecord, PlusFifteenIdSomeStringNameRecord);
        Func<RecordType, Optional<DateOnly?>> map = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.FlatMap(map);
    }

    [Fact]
    public static void FlatMapWithOptional_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<object?>);
        var actual = source.FlatMap(Map);

        var expected = default(FlatArray<RecordStruct>);
        Assert.Equal(expected, actual);

        static Optional<RecordStruct> Map(object? _)
            =>
            new(SomeTextRecordStruct);
    }

    [Fact]
    public static void FlatMapWithOptional_SourceIsNotDefault_ExpectMappedValues()
    {
        var mapper = new Dictionary<string, Optional<RefType?>>
        {
            [EmptyString] = default,
            [SomeString] = MinusFifteenIdRefType,
            [AnotherString] = null
        };

        var source = new FlatArray<string>(mapper.Keys.ToArray());
        var actual = source.FlatMap(Map);

        var expected = new FlatArray<RefType?>(MinusFifteenIdRefType, null);
        Assert.Equal(expected, actual);

        Optional<RefType?> Map(string sourceValue)
            =>
            mapper[sourceValue];
    }
}