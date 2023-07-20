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
    public static void PipeParallel_Result_Four_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<int?, CancellationToken, Task<Result<RecordStruct, Failure<Unit>>>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallel_Result_Four_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
                secondPipeAsync: (Func<int?, CancellationToken, Task<Result<RefType?, Failure<Unit>>>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallel_Result_Four_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
                secondPipeAsync: (_, _) => Task.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
                thirdPipeAsync: (Func<int?, CancellationToken, Task<Result<RecordType, Failure<Unit>>>>)null!,
                fourthPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallel_Result_Four_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
                secondPipeAsync: (_, _) => Task.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
                thirdPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (Func<int?, CancellationToken, Task<Result<string, Failure<Unit>>>>)null!);
    }

    [Fact]
    public static void PipeParallel_Result_Four_FirstResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some first failure message");
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct, Failure<Unit>>>(failure),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));

        var expectedValue = Result.Failure(failure).With<(RecordStruct, RefType?, RecordType, string)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Four_SecondResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some second failure message");
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RefType?, Failure<Unit>>>(failure),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));

        var expectedValue = Result.Failure(failure).With<(RecordStruct, RefType?, RecordType, string)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Four_ThirdResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some third failure message");
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(failure),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));

        var expectedValue = Result.Failure(failure).With<(RecordStruct, RefType?, RecordType, string)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Four_FourthResultIsFailure_ExpectFailureValue()
    {
        var failure = Failure.Create("Some fourth failure message");
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(failure));

        var expectedValue = Result.Failure(failure).With<(RecordStruct, RefType?, RecordType, string)>();
        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public static void PipeParallel_Result_Four_AllResultsAreSuccess_ExpectSuccessValue()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<Result<RecordStruct, Failure<Unit>>>(SomeTextRecordStruct),
            secondPipeAsync: (_, _) => Task.FromResult<Result<RefType?, Failure<Unit>>>(ZeroIdRefType),
            thirdPipeAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(PlusFifteenIdLowerSomeStringNameRecord),
            fourthPipeAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(MixedWhiteSpacesString));

        var expectedValue = (
            SomeTextRecordStruct,
            (RefType?)ZeroIdRefType,
            PlusFifteenIdLowerSomeStringNameRecord,
            MixedWhiteSpacesString);

        var expected = AsyncPipeline.Pipe(Result.Success(expectedValue).With<Failure<Unit>>(), default);

        Assert.StrictEqual(expected, actual);
    }
}