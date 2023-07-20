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
    public static void ForwardParallel_Eight_FirstForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (Func<RefType, CancellationToken, Task<Result<string?, Failure<Unit>>>>)null!,
                secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallel_Eight_SecondForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (Func<RefType, CancellationToken, Task<Result<StructType?, Failure<Unit>>>>)null!,
                thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallel_Eight_ThirdForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (Func<RefType, CancellationToken, Task<Result<byte, Failure<Unit>>>>)null!,
                fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallel_Eight_FourthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (Func<RefType, CancellationToken, Task<Result<DateTimeKind?, Failure<Unit>>>>)null!,
                fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallel_Eight_FifthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (Func<RefType, CancellationToken, Task<Result<RecordType, Failure<Unit>>>>)null!,
                sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallel_Eight_SixthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (Func<RefType, CancellationToken, Task<Result<bool, Failure<Unit>>>>)null!,
                seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallel_Eight_SeventhForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("seventhForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (Func<RefType, CancellationToken, Task<Result<double, Failure<Unit>>>>)null!,
                eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue));
    }

    [Fact]
    public static void ForwardParallel_Eight_EighthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("eighthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
                secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
                fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
                fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
                seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
                eighthForwardAsync: (Func<RefType, CancellationToken, Task<Result<long?, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task ForwardParallel_Eight_SourceResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Eight_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(failure),
            secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Eight_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(failure),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Eight_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(failure),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Eight_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(failure),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Eight_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(failure),
            sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Eight_SixthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some sixth failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(failure),
            seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Eight_SeventhResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some seventh failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(failure),
            eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Eight_EighthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some failure message");
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallel_Eight_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<RefType, Failure<Unit>>(PlusFifteenIdRefType, default);

        var actual = await source.ForwardParallel(
            firstForwardAsync: (_, _) => Task.FromResult<Result<string?, Failure<Unit>>>(SomeString),
            secondForwardAsync: (_, _) => Task.FromResult<Result<StructType?, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => Task.FromResult<Result<byte, Failure<Unit>>>(byte.MaxValue),
            fourthForwardAsync: (_, _) => Task.FromResult<Result<DateTimeKind?, Failure<Unit>>>(DateTimeKind.Utc),
            fifthForwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            sixthForwardAsync: (_, _) => Task.FromResult<Result<bool, Failure<Unit>>>(false),
            seventhForwardAsync: (_, _) => Task.FromResult<Result<double, Failure<Unit>>>(double.Epsilon),
            eighthForwardAsync: (_, _) => Task.FromResult<Result<long?, Failure<Unit>>>(long.MinValue))
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