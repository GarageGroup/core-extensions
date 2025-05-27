using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GarageGroup.Core.Collections.Test;

partial class AsyncPipelineExtensionsTest
{
    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(null, SomeString)]
    [InlineData(-1, EmptyString, AnotherString)]
    [InlineData(0, AnotherString, LowerSomeString, WhiteSpaceString)]
    [InlineData(1, LowerSomeString)]
    [InlineData(5, WhiteSpaceString, EmptyString)]
    public static void ForwardParallel_ArrayUnit_ForwardAsyncIsNull_ExpectArgumentNullException(
        int? degreeOfParallelism, params string?[] input)
    {
        var source = AsyncPipeline.Pipe<FlatArray<string?>, Failure<Unit>>(input.ToFlatArray(), default);

        var option = new PipelineParallelOption
        {
            DegreeOfParallelism = degreeOfParallelism
        };

        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("forwardAsync", ex.ParamName);

        void Test()
            =>
            _ = source.ForwardParallel(
                forwardAsync: null!,
                option: option);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestData))]
    public static async Task ForwardParallel_ArrayUnit_SourceResultIsFailure_ExpectFailureValue(
        PipelineParallelOption? option)
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<FlatArray<RefType?>, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallel(
            forwardAsync: static (_, _) => Task.FromResult(Result.Success<Unit>(default).With<Failure<Unit>>()),
            option: option)
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestData))]
    public static async Task ForwardParallel_ArrayUnit_InputIsEmpty_ExpectSuccessValue(
        PipelineParallelOption? option)
    {
        var input = default(FlatArray<RefType>);
        var source = AsyncPipeline.Pipe<FlatArray<RefType>, Failure<Unit>>(input, default);

        var actual = await source.ForwardParallel(
            forwardAsync: static (_, _) => Task.FromResult(Result.Success<Unit>(default).With<Failure<Unit>>()),
            option: option)
        .ToTask();

        var expected = Result.Success<Unit>(default);

        Assert.StrictEqual(expected, actual);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestData))]
    public static async Task ForwardParallel_ArrayUnit_NotAllResultsAreSuccess_ExpectFailureValue(
        PipelineParallelOption? option)
    {
        var mapper = new Dictionary<RecordStruct, Result<Unit, Failure<Unit>>>
        {
            [SomeTextRecordStruct] = Result.Success<Unit>(default),
            [AnotherTextRecordStruct] = Failure.Create("Some failure message"),
            [UpperAnotherTextRecordStruct] = Result.Success<Unit>(default),
            [default] = Failure.Create("Some message")
        };

        var source = AsyncPipeline.Pipe<FlatArray<RecordStruct>, Failure<Unit>>(mapper.Keys.ToFlatArray(), default);

        var actual = await source.ForwardParallel(
            forwardAsync: (key, _) => Task.FromResult(mapper[key]),
            option: option)
        .ToTask();

        var possibleFailures = new[]
        {
            Failure.Create("Some failure message"),
            Failure.Create("Some message")
        };

        Assert.True(actual.IsFailure);
        Assert.Contains(actual.FailureOrThrow(), possibleFailures);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestData))]
    public static async Task ForwardParallel_ArrayUnit_AllResultsAreSuccess_ExpectSuccessValue(
        PipelineParallelOption? option)
    {
        FlatArray<RecordStruct> input = [SomeTextRecordStruct, UpperAnotherTextRecordStruct];
        var source = AsyncPipeline.Pipe<FlatArray<RecordStruct>, Failure<Unit>>(input, default);

        var actual = await source.ForwardParallel(
            forwardAsync: static (_, _) => Task.FromResult(Result.Success<Unit>(default).With<Failure<Unit>>()),
            option: option)
        .ToTask();

        var expected = Result.Success<Unit>(default);

        Assert.StrictEqual(expected, actual);
    }
}