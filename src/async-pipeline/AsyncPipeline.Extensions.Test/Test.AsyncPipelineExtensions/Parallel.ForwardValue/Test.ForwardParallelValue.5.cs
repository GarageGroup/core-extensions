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
    public static void ForwardParallelValue_Five_FirstForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (Func<RecordType, CancellationToken, ValueTask<Result<RefType, Failure<Unit>>>>)null!,
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallelValue_Five_SecondForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondForwardAsync: (Func<RecordType, CancellationToken, ValueTask<Result<bool, Failure<Unit>>>>)null!,
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallelValue_Five_ThirdForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdForwardAsync: (Func<RecordType, CancellationToken, ValueTask<Result<string, Failure<Unit>>>>)null!,
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallelValue_Five_FourthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthForwardAsync: (Func<RecordType, CancellationToken, ValueTask<Result<RecordStruct?, Failure<Unit>>>>)null!,
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallelValue_Five_FifthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthForwardAsync: (Func<RecordType, CancellationToken, ValueTask<Result<StructType?, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task ForwardParallelValue_Five_SourceResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Five_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(failure),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Five_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(failure),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Five_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(failure),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Five_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(failure),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Five_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Five_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        var expected = (
            ZeroIdRefType,
            false,
            LowerSomeString,
            (RecordStruct?)SomeTextRecordStruct,
            (StructType?)LowerSomeTextStructType);

        Assert.StrictEqual(expected, actual);
    }
}