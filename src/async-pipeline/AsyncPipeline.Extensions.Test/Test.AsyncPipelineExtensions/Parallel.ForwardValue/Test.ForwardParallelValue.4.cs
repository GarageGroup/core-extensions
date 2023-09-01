using System;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GarageGroup.Core.Collections.Test;

partial class AsyncPipelineExtensionsTest
{
    [Fact]
    public static void ForwardParallelValue_Four_FirstForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?, Failure<Unit>>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (Func<int?, CancellationToken, ValueTask<Result<RecordStruct, Failure<Unit>>>>)null!,
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));
    }

    [Fact]
    public static void ForwardParallelValue_Four_SecondForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?, Failure<Unit>>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
                secondForwardAsync: (Func<int?, CancellationToken, ValueTask<Result<RefType?, Failure<Unit>>>>)null!,
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));
    }

    [Fact]
    public static void ForwardParallelValue_Four_ThirdForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?, Failure<Unit>>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
                thirdForwardAsync: (Func<int?, CancellationToken, ValueTask<Result<RecordType, Failure<Unit>>>>)null!,
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));
    }

    [Fact]
    public static void ForwardParallelValue_Four_FourthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?, Failure<Unit>>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                fourthForwardAsync: (Func<int?, CancellationToken, ValueTask<Result<string, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task ForwardParallelValue_Four_SourceResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<int?, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Four_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<int?, Failure<Unit>>(MinusFifteen, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(failure),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Four_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<int?, Failure<Unit>>(MinusFifteen, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(failure),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Four_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<int?, Failure<Unit>>(MinusFifteen, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(failure),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Four_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<int?, Failure<Unit>>(MinusFifteen, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Four_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<int?, Failure<Unit>>(MinusFifteen, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString))
        .ToTask();

        var expected = (
            SomeTextRecordStruct,
            (RefType?)ZeroIdRefType,
            PlusFifteenIdLowerSomeStringNameRecord,
            MixedWhiteSpacesString);

        Assert.StrictEqual(expected, actual);
    }
}