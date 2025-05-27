using System;
using System.Collections.Generic;
using System.Linq;
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
    public static void PipeParallelValue_Result_ArrayUnit_PipeAsyncIsNull_ExpectArgumentNullException(
        int? degreeOfParallelism, params string?[] input)
    {
        var source = AsyncPipeline.Pipe(input.ToFlatArray(), default);

        var option = new PipelineParallelOption
        {
            DegreeOfParallelism = degreeOfParallelism
        };

        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("pipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                pipeAsync: (Func<string?, CancellationToken, ValueTask<Result<Unit, Failure<Unit>>>>)null!,
                option: option);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [1])]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [int.MaxValue])]
    public static async Task PipeParallelValue_Result_ArrayUnit_NotAllResultsAreSuccess_ExpectFailureValue(
        PipelineParallelOption? option, int count)
    {
        var mapper = new Dictionary<RecordStruct, Result<Unit, Failure<Unit>>>
        {
            [SomeTextRecordStruct] = Result.Success<Unit>(default),
            [AnotherTextRecordStruct] = Failure.Create("Some failure message"),
            [UpperAnotherTextRecordStruct] = Result.Success<Unit>(default),
            [default] = Failure.Create("Some message")
        };

        var source = count switch
        {
            1 => AsyncPipeline.Pipe(AnotherTextRecordStruct.AsFlatArray(), default),
            _ => AsyncPipeline.Pipe(mapper.Keys.ToFlatArray(), default)
        };

        var actual = await source.PipeParallelValue(
            pipeAsync: (key, _) => ValueTask.FromResult(mapper[key]),
            option: option)
        .ToTask();

        var possibleFailures = new[]
        {
            Failure.Create("Some failure message"),
            Failure.Create("Some message")
        };

        Assert.True(actual.IsFailure);
        Assert.Contains(actual.FailureOrThrow(), possibleFailures.Take(count));
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [0])]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [1])]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [int.MaxValue])]
    public static async Task PipeParallelValue_Result_ArrayUnit_AllResultsAreSuccess_ExpectSuccessValue(
        PipelineParallelOption? option, int count)
    {
        FlatArray<RecordStruct> input = [SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct];
        var source = AsyncPipeline.Pipe(input.Take(count), default);

        var actual = await source.PipeParallelValue(
            pipeAsync: (key, _) => ValueTask.FromResult(Result.Success<Unit>(default).With<Failure<Unit>>()),
            option: option)
        .ToTask();

        var expected = Result.Success<Unit>(default);

        Assert.StrictEqual(expected, actual);
    }
}