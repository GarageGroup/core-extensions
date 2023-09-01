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
    public static void ForwardParallelValue_Three_FirstForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<string, Failure<Unit>>(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (Func<string, CancellationToken, ValueTask<Result<RecordType?, Failure<Unit>>>>)null!,
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType));
    }

    [Fact]
    public static void ForwardParallelValue_Three_SecondForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<string, Failure<Unit>>(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
                secondForwardAsync: (Func<string, CancellationToken, ValueTask<Result<StructType, Failure<Unit>>>>)null!,
                thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType));
    }

    [Fact]
    public static void ForwardParallelValue_Three_ThirdForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<string, Failure<Unit>>(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
                thirdForwardAsync: (Func<string, CancellationToken, ValueTask<Result<RefType, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task ForwardParallelValue_Three_SourceResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<string, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Three_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<string, Failure<Unit>>(AnotherString, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(failure),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Three_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<string, Failure<Unit>>(AnotherString, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(failure),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Three_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<string, Failure<Unit>>(AnotherString, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Three_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<string, Failure<Unit>>(AnotherString, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
            thirdForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType))
        .ToTask();

        var expected = (
            (RecordType?)ZeroIdNullNameRecord,
            SomeTextStructType,
            MinusFifteenIdRefType);

        Assert.StrictEqual(expected, actual);
    }
}