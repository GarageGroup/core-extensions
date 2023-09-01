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
    public static void PipeParallelValue_Result_Seven_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<decimal, Failure<Unit>>>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Result_Seven_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<RefType?, Failure<Unit>>>>)null!,
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Result_Seven_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<string, Failure<Unit>>>>)null!,
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Result_Seven_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<DateOnly, Failure<Unit>>>>)null!,
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Result_Seven_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<bool?, Failure<Unit>>>>)null!,
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Result_Seven_SixthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<StructType, Failure<Unit>>>>)null!,
                seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Result_Seven_SeventhPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("seventhPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                seventhPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<Result<long?[], Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Seven_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(failure),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Seven_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(failure),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Seven_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(failure),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Seven_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(failure),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Seven_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(failure),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Seven_SixthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some sixth failure message");
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(failure),
            seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Seven_SeventhResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some seventh failure message");
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(failure),
            seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Seven_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.One),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(MinusFifteenIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(AnotherString),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<DateOnly, Failure<Unit>>>(new DateOnly(2021, 01, 15)),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<bool?, Failure<Unit>>>(true),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            seventhPipeAsync: (_, _) => ValueTask.FromResult<Result<long?[], Failure<Unit>>>(Array.Empty<long?>()))
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