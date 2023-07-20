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
    public static void ForwardParallel_Five_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstPipeAsync: (Func<RecordType, CancellationToken, Task<Result<RefType, Failure<Unit>>>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallel_Five_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondPipeAsync: (Func<RecordType, CancellationToken, Task<Result<bool, Failure<Unit>>>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallel_Five_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdPipeAsync: (Func<RecordType, CancellationToken, Task<Result<string, Failure<Unit>>>>)null!,
                fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallel_Five_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthPipeAsync: (Func<RecordType, CancellationToken, Task<Result<RecordStruct?, Failure<Unit>>>>)null!,
                fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));
    }

    [Fact]
    public static void ForwardParallel_Five_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
                secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
                fifthPipeAsync: (Func<RecordType, CancellationToken, Task<Result<StructType?, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static void ForwardParallel_Five_SourceResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(failure, default);

        var actual = _ = source.ForwardParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));

        var expectedValue = Result.Failure(failure).With<(RefType, bool, string, RecordStruct?, StructType?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void ForwardParallel_Five_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = _ = source.ForwardParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(failure),
            secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));

        var expectedValue = Result.Failure(failure).With<(RefType, bool, string, RecordStruct?, StructType?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void ForwardParallel_Five_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = _ = source.ForwardParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(failure),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));

        var expectedValue = Result.Failure(failure).With<(RefType, bool, string, RecordStruct?, StructType?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void ForwardParallel_Five_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = _ = source.ForwardParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(failure),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));

        var expectedValue = Result.Failure(failure).With<(RefType, bool, string, RecordStruct?, StructType?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void ForwardParallel_Five_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = _ = source.ForwardParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(failure),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));

        var expectedValue = Result.Failure(failure).With<(RefType, bool, string, RecordStruct?, StructType?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void ForwardParallel_Five_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = _ = source.ForwardParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(failure));

        var expectedValue = Result.Failure(failure).With<(RefType, bool, string, RecordStruct?, StructType?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void ForwardParallel_Five_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<RecordType, Failure<Unit>>(MinusFifteenIdNullNameRecord, default);

        var actual = _ = source.ForwardParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType),
            secondPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(LowerSomeString),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct?, Failure<Unit>>>(SomeTextRecordStruct),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(LowerSomeTextStructType));

        var expectedValue = (
            ZeroIdRefType,
            false,
            LowerSomeString,
            (RecordStruct?)SomeTextRecordStruct,
            (StructType?)LowerSomeTextStructType);

        var expected = AsyncPipeline.Pipe(Result.Success(expectedValue).With<Failure<Unit>>(), default);

        Assert.StrictEqual(expected, actual);
    }
}