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
    public static void ForwardParallelValue_Two_FirstForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType?, Failure<Unit>>(PlusFifteenIdLowerSomeStringNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (Func<RecordType?, CancellationToken, ValueTask<Result<StructType, Failure<Unit>>>>)null!,
                secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType));
    }

    [Fact]
    public static void ForwardParallelValue_Two_SecondForwardAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType?, Failure<Unit>>(PlusFifteenIdLowerSomeStringNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondForwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallelValue(
                firstForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
                secondForwardAsync: (Func<RecordType?, CancellationToken, ValueTask<Result<RefType, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task ForwardParallelValue_Two_SourceResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<RecordType?, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Two_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<RecordType?, Failure<Unit>>(PlusFifteenIdLowerSomeStringNameRecord, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(failure),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Two_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<RecordType?, Failure<Unit>>(PlusFifteenIdLowerSomeStringNameRecord, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task ForwardParallelValue_Two_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<RecordType?, Failure<Unit>>(PlusFifteenIdLowerSomeStringNameRecord, default);

        var actual = await source.ForwardParallelValue(
            firstForwardAsync: (_, _) => ValueTask.FromResult<Result<StructType, Failure<Unit>>>(LowerSomeTextStructType),
            secondForwardAsync: (_, _) => ValueTask.FromResult<Result<RefType, Failure<Unit>>>(ZeroIdRefType))
        .ToTask();

        var expected = (
            LowerSomeTextStructType,
            ZeroIdRefType);

        Assert.StrictEqual(expected, actual);
    }
}