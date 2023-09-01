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
    public static void ForwardParallelValue_Eight_FirstForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (Func<RefType, CancellationToken, ValueTask<Result<string?, Failure<Unit>>>>)null!,
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallelValue_Eight_SecondForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (Func<RefType, CancellationToken, ValueTask<Result<StructType?, Failure<Unit>>>>)null!,
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallelValue_Eight_ThirdForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (Func<RefType, CancellationToken, ValueTask<Result<byte, Failure<Unit>>>>)null!,
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallelValue_Eight_FourthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (Func<RefType, CancellationToken, ValueTask<Result<DateTimeKind?, Failure<Unit>>>>)null!,
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallelValue_Eight_FifthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (Func<RefType, CancellationToken, ValueTask<Result<RecordType, Failure<Unit>>>>)null!,
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallelValue_Eight_SixthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (Func<RefType, CancellationToken, ValueTask<Result<bool, Failure<Unit>>>>)null!,
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallelValue_Eight_SeventhForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("seventhForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (Func<RefType, CancellationToken, ValueTask<Result<double, Failure<Unit>>>>)null!,
                eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallelValue_Eight_EighthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("eighthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (Func<RefType, CancellationToken, ValueTask<Result<long?, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task ForwardParallelValue_Eight_SourceResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Eight_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(failure),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Eight_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(failure),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Eight_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(failure),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Eight_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(failure),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Eight_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(failure),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Eight_SixthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some sixth failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(failure),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Eight_SeventhResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some seventh failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(failure),
            eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Eight_EighthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Eight_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => ValueTask.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => ValueTask.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
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