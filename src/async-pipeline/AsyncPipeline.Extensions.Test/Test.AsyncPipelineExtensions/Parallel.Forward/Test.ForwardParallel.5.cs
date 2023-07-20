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
    public static void ForwardParallel_Five_FirstForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (Func<RecordType, CancellationToken, Task<Result<RefType, Failure<Unit>>>>)null!,
                secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallel_Five_SecondForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondForwardAsync: (Func<RecordType, CancellationToken, Task<Result<bool, Failure<Unit>>>>)null!,
                thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallel_Five_ThirdForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdForwardAsync: (Func<RecordType, CancellationToken, Task<Result<string, Failure<Unit>>>>)null!,
                fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallel_Five_FourthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthForwardAsync: (Func<RecordType, CancellationToken, Task<Result<RecordStruct?, Failure<Unit>>>>)null!,
                fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallel_Five_FifthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthForwardAsync: (Func<RecordType, CancellationToken, Task<Result<StructType?, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task ForwardParallel_Five_SourceResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Five_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(failure),
            secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Five_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(failure),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Five_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(failure),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Five_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(failure),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Five_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Five_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType))
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