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
    public static void ForwardParallel_Array_ForwardAsyncIsNull_ExpectArgumentNullException(
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
                forwardAsync: (Func<string?, CancellationToken, Task<Result<RecordType, Failure<Unit>>>>)null!,
                option: option);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestData))]
    public static async Task ForwardParallel_Array_SourceResultIsFailure_ExpectFailureValue(
        PipelineParallelOption? option)
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<FlatArray<RefType?>, Failure<Unit>>(failure, default);

        var actual = await source.ForwardParallel(
            forwardAsync: static (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(MinusFifteenIdNullNameRecord),
            option: option)
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [1])]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [int.MaxValue])]
    public static async Task ForwardParallel_Array_NotAllResultsAreSuccess_ExpectFailureValue(
        PipelineParallelOption? option, int count)
    {
        var mapper = new Dictionary<RecordStruct, Result<RecordType?, Failure<Unit>>>
        {
            [SomeTextRecordStruct] = MinusFifteenIdSomeStringNameRecord,
            [AnotherTextRecordStruct] = Failure.Create("Some failure message"),
            [UpperAnotherTextRecordStruct] = ZeroIdNullNameRecord,
            [default] = Failure.Create("Some message")
        };

        var source = count switch
        {
            1 => AsyncPipeline.Pipe<FlatArray<RecordStruct>, Failure<Unit>>(AnotherTextRecordStruct.AsFlatArray(), default),
            _ => AsyncPipeline.Pipe<FlatArray<RecordStruct>, Failure<Unit>>(mapper.Keys.ToFlatArray(), default)
        };

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
        Assert.Contains(actual.FailureOrThrow(), possibleFailures.Take(count));
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [0])]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [1])]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [int.MaxValue])]
    public static async Task ForwardParallel_Array_AllResultsAreSuccess_ExpectSuccessArrayValue(
        PipelineParallelOption? option, int count)
    {
        var mapper = new Dictionary<RecordStruct, Result<RecordType?, Failure<Unit>>>
        {
            [SomeTextRecordStruct] = MinusFifteenIdSomeStringNameRecord,
            [AnotherTextRecordStruct] = null,
            [UpperAnotherTextRecordStruct] = ZeroIdNullNameRecord
        };

        var source = AsyncPipeline.Pipe<FlatArray<RecordStruct>, Failure<Unit>>(mapper.Keys.ToFlatArray().Take(count), default);

        var actual = await source.ForwardParallel(
            forwardAsync: (key, _) => Task.FromResult(mapper[key]),
            option: option)
        .ToTask();

        FlatArray<RecordType?> expected = [MinusFifteenIdSomeStringNameRecord, null, ZeroIdNullNameRecord];

        Assert.StrictEqual(expected.Take(count), actual);
    }
}