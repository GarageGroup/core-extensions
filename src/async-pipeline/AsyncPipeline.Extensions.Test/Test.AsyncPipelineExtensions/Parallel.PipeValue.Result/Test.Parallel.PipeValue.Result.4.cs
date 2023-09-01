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
    public static void PipeParallelValue_Result_Four_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<int?, CancellationToken, ValueTask<Result<RecordStruct, Failure<Unit>>>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallelValue_Result_Four_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
                secondPipeAsync: (Func<int?, CancellationToken, ValueTask<Result<RefType?, Failure<Unit>>>>)null!,
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallelValue_Result_Four_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
                thirdPipeAsync: (Func<int?, CancellationToken, ValueTask<Result<RecordType, Failure<Unit>>>>)null!,
                fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallelValue_Result_Four_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
                secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (Func<int?, CancellationToken, ValueTask<Result<string, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Four_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(failure),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Four_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(failure),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Four_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(failure),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Four_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(failure))
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Fact]
    public static async Task PipeParallelValue_Result_Four_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondPipeAsync: (_, _) => ValueTask.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString))
        .ToTask();

        var expected = (
            SomeTextRecordStruct,
            (RefType?)ZeroIdRefType,
            PlusFifteenIdLowerSomeStringNameRecord,
            MixedWhiteSpacesString);

        Assert.StrictEqual(expected, actual);
    }
}