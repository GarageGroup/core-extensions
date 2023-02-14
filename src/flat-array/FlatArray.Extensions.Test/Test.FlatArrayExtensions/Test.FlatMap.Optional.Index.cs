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
    public static void FlatMapWithOptionalWithIndex_MapArgumentIsNull_ExpectArgumentNullException(bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new FlatArray<bool?>(true, false, null);
        Func<bool?, int, Optional<RefType>> map = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.FlatMap(map);
    }

    [Fact]
    public static void FlatMapWithOptionalWithIndex_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<RecordType>);
        var actual = source.FlatMap(Map);

        var expected = default(FlatArray<RefType>);
        Assert.Equal(expected, actual);

        static Optional<RefType> Map(RecordType _, int index)
            =>
            MinusFifteenIdRefType;
    }

    [Fact]
    public static void FlatMapWithOptionalWithIndex_SourceIsNotDefault_ExpectMappedValues()
    {
        var mapper = new Dictionary<string, Optional<RecordType?>>
        {
            [TabString] = MinusFifteenIdNullNameRecord,
            [AnotherString] = null,
            [SomeString] = default,
            [LowerAnotherString] = PlusFifteenIdLowerSomeStringNameRecord
        };

        var source = new FlatArray<string>(mapper.Keys.ToArray());
        var actual = source.FlatMap(Map);

        var expected = new FlatArray<RecordType?>(MinusFifteenIdNullNameRecord, null, PlusFifteenIdLowerSomeStringNameRecord);
        Assert.Equal(expected, actual);

        Optional<RecordType?> Map(string sourceValue, int index)
        {
            Assert.Equal(source[index], sourceValue);
            return mapper[sourceValue];
        }
    }
}