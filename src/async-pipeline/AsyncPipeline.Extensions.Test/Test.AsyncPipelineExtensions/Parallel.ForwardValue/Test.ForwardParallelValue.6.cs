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
    public static void ForwardParallelValue_Six_FirstForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (Func<StructType?, CancellationToken, ValueTask<Result<TimeOnly, Failure<Unit>>>>)null!,
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void ForwardParallelValue_Six_SecondForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondForwardAsync: (Func<StructType?, CancellationToken, ValueTask<Result<RecordType, Failure<Unit>>>>)null!,
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void ForwardParallelValue_Six_ThirdForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdForwardAsync: (Func<StructType?, CancellationToken, ValueTask<Result<object?, Failure<Unit>>>>)null!,
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void ForwardParallelValue_Six_FourthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthForwardAsync: (Func<StructType?, CancellationToken, ValueTask<Result<RefType, Failure<Unit>>>>)null!,
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void ForwardParallelValue_Six_FifthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthForwardAsync: (Func<StructType?, CancellationToken, ValueTask<Result<decimal, Failure<Unit>>>>)null!,
                sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void ForwardParallelValue_Six_SixthForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthForwardAsync: (Func<StructType?, CancellationToken, ValueTask<Result<int?, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task ForwardParallelValue_Six_SourceResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Six_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(failure),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Six_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(failure),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Six_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(failure),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Six_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(failure),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Six_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(failure),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Six_SixthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some sixth failure message");
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Six_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<StructType?, Failure<Unit>>(SomeTextStructType, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthForwardAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthForwardAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        var expected = (
            new TimeOnly(15, 32, 51),
            ZeroIdNullNameRecord,
            (object?)null,
            PlusFifteenIdRefType,
            decimal.MaxValue,
            (int?)MinusOne);

        Assert.StrictEqual(expected, actual);
    }
}