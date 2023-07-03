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
    public static void LastOrAbsentWithPredicate_PredicateIsNull_ExpectArgumentNullException(bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new FlatArray<RecordStruct?>(SomeTextRecordStruct, AnotherTextRecordStruct);

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("predicate", ex.ParamName);

        void Test()
            =>
            _ = source.LastOrAbsent(null!);
    }

    [Fact]
    public static void LastOrAbsentWithPredicate_SourceIsEmpty_ExpectAbsent()
    {
        var source = FlatArray<RefType>.Empty;

        var actual = source.LastOrAbsent(Predicate);
        var expected = Optional.Absent<RefType>();

        Assert.Equal(expected, actual);

        static bool Predicate(RefType _)
            =>
            true;
    }

    [Fact]
    public static void LastOrAbsentWithPredicate_AllConditionsAreFalse_ExpectAbsent()
    {
        var source = new FlatArray<byte?>(0, null, byte.MaxValue);

        var actual = source.LastOrAbsent(Predicate);
        var expected = Optional.Absent<byte?>();

        Assert.Equal(expected, actual);

        static bool Predicate(byte? _)
            =>
            false;
    }

    [Fact]
    public static void LastOrAbsentWithPredicate_NotAllConditionsAreFalse_ExpectLastSuccessItem()
    {
        var mapper = new Dictionary<string, bool>
        {
            { AnotherString, true },
            { string.Empty, false },
            { LowerAnotherString, true },
            { UpperSomeString, true },
            { SomeString, false }
        };

        var source = mapper.Keys.ToFlatArray();

        var actual = source.LastOrAbsent(Predicate);
        var expected = Optional.Present(UpperSomeString);

        Assert.Equal(expected, actual);

        bool Predicate(string item)
            =>
            mapper[item];
    }
}