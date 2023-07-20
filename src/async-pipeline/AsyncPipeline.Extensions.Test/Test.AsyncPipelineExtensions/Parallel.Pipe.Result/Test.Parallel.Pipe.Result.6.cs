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
    public static void PipeParallel_Result_Six_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<StructType?, CancellationToken, Task<Result<TimeOnly, Failure<Unit>>>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void PipeParallel_Result_Six_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (Func<StructType?, CancellationToken, Task<Result<RecordType, Failure<Unit>>>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void PipeParallel_Result_Six_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdPipeAsync: (Func<StructType?, CancellationToken, Task<Result<object?, Failure<Unit>>>>)null!,
                fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void PipeParallel_Result_Six_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthPipeAsync: (Func<StructType?, CancellationToken, Task<Result<RefType, Failure<Unit>>>>)null!,
                fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void PipeParallel_Result_Six_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthPipeAsync: (Func<StructType?, CancellationToken, Task<Result<decimal, Failure<Unit>>>>)null!,
                sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));
    }

    [Fact]
    public static void PipeParallel_Result_Six_SixthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
                sixthPipeAsync: (Func<StructType?, CancellationToken, Task<Result<int?, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static void PipeParallel_Result_Six_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(failure),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));

        var expectedValue = Result.Failure(failure).With<(TimeOnly, RecordType, object?, RefType, decimal, int?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Six_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(failure),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));

        var expectedValue = Result.Failure(failure).With<(TimeOnly, RecordType, object?, RefType, decimal, int?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Six_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(failure),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));

        var expectedValue = Result.Failure(failure).With<(TimeOnly, RecordType, object?, RefType, decimal, int?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Six_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(failure),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));

        var expectedValue = Result.Failure(failure).With<(TimeOnly, RecordType, object?, RefType, decimal, int?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Six_FifthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fifth failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(failure),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));

        var expectedValue = Result.Failure(failure).With<(TimeOnly, RecordType, object?, RefType, decimal, int?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Six_SixthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some sixth failure message");
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(failure));

        var expectedValue = Result.Failure(failure).With<(TimeOnly, RecordType, object?, RefType, decimal, int?)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Six_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<TimeOnly, Failure<Unit>>>(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<object?, Failure<Unit>>>(null),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => Task.FromResult<Result<decimal, Failure<Unit>>>(decimal.MaxValue),
            sixthPipeAsync: (_, _) => Task.FromResult<Result<int?, Failure<Unit>>>(MinusOne));

        var expectedValue = (
            new TimeOnly(15, 32, 51),
            ZeroIdNullNameRecord,
            (object?)null,
            PlusFifteenIdRefType,
            decimal.MaxValue,
            (int?)MinusOne);

        var expected = AsyncPipeline.Pipe(Result.Success(expectedValue).With<Failure<Unit>>(), default);

        Assert.StrictEqual(expected, actual);
    }
}