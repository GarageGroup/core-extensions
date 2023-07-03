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
    public static void MapWithIndex_MapArgumentIsNull_ExpectArgumentNullException(bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new FlatArray<RefType?>(PlusFifteenIdRefType, MinusFifteenIdRefType);
        Func<RefType?, int, RecordType> map = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.Map(map);
    }

    [Fact]
    public static void MapWithIndex_SourceIsDefault_ExpectDefault()
    {
        var source = default(FlatArray<string>);
        var actual = source.Map(Map);

        var expected = default(FlatArray<RecordType?>);
        Assert.Equal(expected, actual);

        static RecordType? Map(string _, int index)
            =>
            ZeroIdNullNameRecord;
    }

    [Fact]
    public static void MapWithIndex_SourceIsNotDefault_ExpectMappedValues()
    {
        var mapper = new Dictionary<RefType, string?>
        {
            [MinusFifteenIdRefType] = SomeString,
            [PlusFifteenIdRefType] = null,
            [ZeroIdRefType] = AnotherString
        };

        var source = new FlatArray<RefType>(mapper.Keys.ToArray());
        var actual = source.Map(Map);

        var expected = new FlatArray<string?>(mapper.Values.ToArray());
        Assert.Equal(expected, actual);

        string? Map(RefType sourceValue, int index)
        {
            Assert.Equal(source[index], sourceValue);
            return mapper[sourceValue];
        }
    }
}