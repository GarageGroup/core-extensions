using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GarageGroup.Core.Collections.Test;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public static void Filter_PredicateIsNull_ExpectArgumentNullException(bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new FlatArray<string>(SomeString, LowerSomeString);

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("predicate", ex.ParamName);

        void Test()
            =>
            _ = source.Filter(null!);
    }

    [Fact]
    public static void Filter_SourceIsEmpty_ExpectDefault()
    {
        var source = FlatArray<RecordType>.Empty;
        var actual = source.Filter(Predicate);

        var expected = default(FlatArray<RecordType>);
        Assert.Equal(expected, actual);

        static bool Predicate(RecordType _)
            =>
            true;
    }

    [Fact]
    public static void Filter_SourceIsNotEmpty_ExpectFilteredValues()
    {
        var mapper = new Dictionary<int, bool>
        {
            { MinusFifteen, false },
            { Zero, true },
            { MinusOne, true },
            { One, false },
            { PlusFifteen, true }
        };

        var source = mapper.Keys.ToFlatArray();

        var actual = source.Filter(Predicate);
        var expected = new FlatArray<int>(Zero, MinusOne, PlusFifteen);

        Assert.Equal(expected, actual);

        bool Predicate(int item)
            =>
            mapper[item];
    }
}