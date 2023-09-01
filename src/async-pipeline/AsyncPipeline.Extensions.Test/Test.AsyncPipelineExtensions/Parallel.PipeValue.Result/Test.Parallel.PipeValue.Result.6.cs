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
    public static void PipeParallelValue_Result_Six_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<StructType?, CancellationToken, ValueTask<Result<TimeOnly, Failure<Unit>>>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void PipeParallelValue_Result_Six_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (Func<StructType?, CancellationToken, ValueTask<Result<RecordType, Failure<Unit>>>>)null!,
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void PipeParallelValue_Result_Six_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdPipeAsync: (Func<StructType?, CancellationToken, ValueTask<Result<object?, Failure<Unit>>>>)null!,
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void PipeParallelValue_Result_Six_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthPipeAsync: (Func<StructType?, CancellationToken, ValueTask<Result<RefType, Failure<Unit>>>>)null!,
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void PipeParallelValue_Result_Six_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthPipeAsync: (Func<StructType?, CancellationToken, ValueTask<Result<decimal, Failure<Unit>>>>)null!,
                sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void PipeParallelValue_Result_Six_SixthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthPipeAsync: (Func<StructType?, CancellationToken, ValueTask<Result<int?, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Six_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(failure),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Six_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(failure),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Six_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(failure),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Six_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(failure),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Six_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(failure),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Six_SixthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some sixth failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Six_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<Result<int?, Failure<Unit>>>(MinusOne))
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