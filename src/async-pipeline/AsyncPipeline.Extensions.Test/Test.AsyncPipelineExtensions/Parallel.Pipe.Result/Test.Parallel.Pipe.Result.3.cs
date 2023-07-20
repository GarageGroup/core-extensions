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
    public static void PipeParallel_Result_Three_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<string, CancellationToken, Task<Result<RecordType?, Failure<Unit>>>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType));
    }

    [Fact]
    public static void PipeParallel_Result_Three_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
                secondPipeAsync: (Func<string, CancellationToken, Task<Result<StructType, Failure<Unit>>>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType));
    }

    [Fact]
    public static void PipeParallel_Result_Three_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
                secondPipeAsync: (_, _) => Task.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
                thirdPipeAsync: (Func<string, CancellationToken, Task<Result<RefType, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static void PipeParallel_Result_Three_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe(AnotherString, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RecordType?, Failure<Unit>>>(failure),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType));

        var expectedValue = Result.Failure(failure).With<(RecordType?, StructType, RefType)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Three_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe(AnotherString, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType, Failure<Unit>>>(failure),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType));

        var expectedValue = Result.Failure(failure).With<(RecordType?, StructType, RefType)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Three_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe(AnotherString, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(failure));

        var expectedValue = Result.Failure(failure).With<(RecordType?, StructType, RefType)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Three_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RecordType?, Failure<Unit>>>(ZeroIdNullNameRecord),
            secondPipeAsync: (_, _) => Task.FromResult<Result<StructType, Failure<Unit>>>(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(MinusFifteenIdRefType));

        var expectedValue = (
            (RecordType?)ZeroIdNullNameRecord,
            SomeTextStructType,
            MinusFifteenIdRefType);

        var expected = AsyncPipeline.Pipe(Result.Success(expectedValue).With<Failure<Unit>>(), default);

        Assert.StrictEqual(expected, actual);
    }
}