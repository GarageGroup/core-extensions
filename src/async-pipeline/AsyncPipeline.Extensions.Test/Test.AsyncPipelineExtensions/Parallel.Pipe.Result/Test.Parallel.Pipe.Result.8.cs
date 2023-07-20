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
    public static void PipeParallel_Result_Eight_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<RefType, CancellationToken, Task<Result<string?, Failure<Unit>>>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Result_Eight_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondPipeAsync: (Func<RefType, CancellationToken, Task<Result<StructType?, Failure<Unit>>>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Result_Eight_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (Func<RefType, CancellationToken, Task<Result<byte, Failure<Unit>>>>)null!,
                fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Result_Eight_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthPipeAsync: (Func<RefType, CancellationToken, Task<Result<DateTimeKind?, Failure<Unit>>>>)null!,
                fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Result_Eight_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthPipeAsync: (Func<RefType, CancellationToken, Task<Result<RecordType, Failure<Unit>>>>)null!,
                sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Result_Eight_SixthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (Func<RefType, CancellationToken, Task<Result<bool, Failure<Unit>>>>)null!,
                seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Result_Eight_SeventhPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("seventhPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhPipeAsync: (Func<RefType, CancellationToken, Task<Result<double, Failure<Unit>>>>)null!,
                eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Result_Eight_EighthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("eighthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthPipeAsync: (Func<RefType, CancellationToken, Task<Result<long?, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task PipeParallel_Result_Eight_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(failure),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallel_Result_Eight_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(failure),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallel_Result_Eight_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(failure),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallel_Result_Eight_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(failure),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallel_Result_Eight_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(failure),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallel_Result_Eight_SixthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some sixth failure message");
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(failure),
            seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallel_Result_Eight_SeventhResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some seventh failure message");
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(failure),
            eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallel_Result_Eight_EighthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some failure message");
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallel_Result_Eight_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhPipeAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthPipeAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        var expected = (
            (string?)SomeString,
            (StructType?)SomeTextStructType,
            byte.MaxValue,
            (DateTimeKind?)DateTimeKind.Utc,
            PlusFifteenIdLowerSomeStringNameRecord,
            false,
            double.Epsilon,
            (long?)long.MinValue);

        Assert.StrictEqual(expected, actual);
    }
}