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
    public static void ForwardParallelValue_Seven_FirstForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<decimal, Failure<Unit>>>>)null!,
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void ForwardParallelValue_Seven_SecondForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondForwardAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<RefType?, Failure<Unit>>>>)null!,
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void ForwardParallelValue_Seven_ThirdForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdForwardAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<string, Failure<Unit>>>>)null!,
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void ForwardParallelValue_Seven_FourthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthForwardAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<DateOnly, Failure<Unit>>>>)null!,
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void ForwardParallelValue_Seven_FifthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthForwardAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<bool?, Failure<Unit>>>>)null!,
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void ForwardParallelValue_Seven_SixthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthForwardAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<StructType, Failure<Unit>>>>)null!,
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void ForwardParallelValue_Seven_SeventhForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("seventhForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhForwardAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<long?[], Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task ForwardParallelValue_Seven_SourceResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Seven_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(failure),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Seven_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(failure),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Seven_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(failure),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Seven_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(failure),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Seven_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(failure),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Seven_SixthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some sixth failure message");
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(failure),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Seven_SeventhResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some seventh failure message");
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(failure),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Seven_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<RecordStruct, Failure<Unit>>(SomeTextRecordStruct, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        var expected = (
            decimal.One,
            (RefType?)MinusFifteenIdRefType,
            AnotherString,
            new DateOnly(2021, 01, 15),
            (bool?)true,
            LowerSomeTextStructType,
            Array.Empty<long?>());

        Assert.StrictEqual(expected, actual);
    }
}