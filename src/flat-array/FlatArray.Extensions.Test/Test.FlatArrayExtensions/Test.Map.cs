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
    public static void Map_MapArgumentIsNull_ExpectArgumentNullException(bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new FlatArray<int>(PlusFifteen, Zero, MinusOne);
        Func<int, RecordType> map = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.Map(map);
    }

    [Fact]
    public static void Map_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<RecordStruct>);
        var actual = source.Map(Map);

        var expected = default(FlatArray<RefType>);
        Assert.Equal(expected, actual);

        static RefType Map(RecordStruct _)
            =>
            MinusFifteenIdRefType;
    }

    [Fact]
    public static void Map_SourceIsNotDefault_ExpectMappedValues()
    {
        var mapper = new Dictionary<string, RecordType>
        {
            [SomeString] = PlusFifteenIdLowerSomeStringNameRecord,
            [AnotherString] = ZeroIdNullNameRecord,
            [MixedWhiteSpacesString] = MinusFifteenIdSomeStringNameRecord
        };

        var source = new FlatArray<string>(mapper.Keys.ToArray());
        var actual = source.Map(Map);

        var expected = new FlatArray<RecordType>(mapper.Values.ToArray());
        Assert.Equal(expected, actual);

        RecordType Map(string sourceValue)
            =>
            mapper[sourceValue];
    }
}
