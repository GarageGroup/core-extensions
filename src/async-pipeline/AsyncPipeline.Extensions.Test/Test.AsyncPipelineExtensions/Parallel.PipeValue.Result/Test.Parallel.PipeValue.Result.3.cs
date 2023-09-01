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
    public static void PipeParallelValue_Result_Three_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<string, CancellationToken, ValueTask<Result<RecordType?, Failure<Unit>>>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType));
    }

    [Fact]
    public static void PipeParallelValue_Result_Three_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
                secondPipeAsync: (Func<string, CancellationToken, ValueTask<Result<StructType, Failure<Unit>>>>)null!,
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType));
    }

    [Fact]
    public static void PipeParallelValue_Result_Three_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (Func<string, CancellationToken, ValueTask<Result<RefType, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Three_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe(AnotherString, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(failure),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Three_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe(AnotherString, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(failure),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Three_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe(AnotherString, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Three_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType))
        .ToTask();

        var expected = (
            (RecordType?)ZeroIdNullNameRecord,
            SomeTextStructType,
            MinusFifteenIdRefType);

        Assert.StrictEqual(expected, actual);
    }
}