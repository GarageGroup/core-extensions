using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GGroupp.Core.Collections.Test;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public static void FirstOrAbsentWithPredicate_PredicateIsNull_ExpectArgumentNullException(bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new FlatArray<int?>(null, MinusOne);

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("predicate", ex.ParamName);

        void Test()
            =>
            _ = source.FirstOrAbsent(null!);
    }

    [Fact]
    public static void FirstOrAbsentWithPredicate_SourceIsEmpty_ExpectAbsent()
    {
        var source = FlatArray<StructType>.Empty;

        var actual = source.FirstOrAbsent(Predicate);
        var expected = Optional.Absent<StructType>();

        Assert.Equal(expected, actual);

        static bool Predicate(StructType _)
            =>
            true;
    }

    [Fact]
    public static void FirstOrAbsentWithPredicate_AllConditionsAreFalse_ExpectAbsent()
    {
        var source = new FlatArray<RecordStruct>(SomeTextRecordStruct, AnotherTextRecordStruct);

        var actual = source.FirstOrAbsent(Predicate);
        var expected = Optional.Absent<RecordStruct>();

        Assert.Equal(expected, actual);

        static bool Predicate(RecordStruct _)
            =>
            false;
    }

    [Fact]
    public static void FirstOrAbsentWithPredicate_NotAllConditionsAreFalse_ExpectFirstSuccessItem()
    {
        var mapper = new Dictionary<RecordType, bool>
        {
            { ZeroIdNullNameRecord, false },
            { PlusFifteenIdLowerSomeStringNameRecord, true },
            { MinusFifteenIdSomeStringNameRecord, true },
            { MinusFifteenIdNullNameRecord, false }
        };

        var source = mapper.Keys.ToFlatArray();

        var actual = source.FirstOrAbsent(Predicate);
        var expected = Optional.Present(PlusFifteenIdLowerSomeStringNameRecord);

        Assert.Equal(expected, actual);

        bool Predicate(RecordType item)
            =>
            mapper[item];
    }
}