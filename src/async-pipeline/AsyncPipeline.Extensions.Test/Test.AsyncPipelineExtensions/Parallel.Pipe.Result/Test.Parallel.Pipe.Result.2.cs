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
    public static void PipeParallel_Result_Two_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<RecordType?, CancellationToken, Task<Result<StructType, Failure<Unit>>>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType));
    }

    [Fact]
    public static void PipeParallel_Result_Two_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                secondPipeAsync: (Func<RecordType?, CancellationToken, Task<Result<RefType, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task PipeParallel_Result_Two_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<StructType, Failure<Unit>>>(failure),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallel_Result_Two_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallel_Result_Two_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType))
        .ToTask();

        var expected = (
            LowerSomeTextStructType,
            ZeroIdRefType);

        Assert.StrictEqual(expected, actual);
    }
}