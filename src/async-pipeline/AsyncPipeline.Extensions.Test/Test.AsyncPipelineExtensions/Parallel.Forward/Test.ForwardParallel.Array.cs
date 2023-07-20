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
    [InlineData(null)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    public static async Task ForwardParallel_Array_SourceResultIsFailure_ExpectFailureValue(
        int? degreeOfParallelism)
    {
        var failure = Failure.Create("Some source failure message");
        var source = AsyncPipeline.Pipe<FlatArray<RefType?>, Failure<Unit>>(failure, default);

        var option = new PipelineParallelOption
        {
            DegreeOfParallelism = degreeOfParallelism
        };

        var actual = await source.ForwardParallel(
            forwardAsync: (_, _) => Task.FromResult<Result<RecordType, Failure<Unit>>>(MinusFifteenIdNullNameRecord),
            option: option)
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    public static async Task ForwardParallel_Array_InputIsEmpty_ExpectSuccessEmptyArrayValue(
        int? degreeOfParallelism)
    {
        var sourceValue = default(FlatArray<RefType>);
        var source = AsyncPipeline.Pipe<FlatArray<RefType>, Failure<Unit>>(sourceValue, default);

        var option = new PipelineParallelOption
        {
            DegreeOfParallelism = degreeOfParallelism
        };

        var actual = await source.ForwardParallel(
            forwardAsync: (_, _) => Task.FromResult<Result<string, Failure<Unit>>>(SomeString),
            option: option)
        .ToTask();

        var expected = default(FlatArray<string>);

        Assert.StrictEqual(expected, actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    public static async Task ForwardParallel_Array_NotAllResultsAreSuccess_ExpectFailureValue(
        int? degreeOfParallelism)
    {
        var failure = Failure.Create("Some failure message");

        var mapper = new Dictionary<RecordStruct, Result<RecordType?, Failure<Unit>>>
        {
            [SomeTextRecordStruct] = MinusFifteenIdSomeStringNameRecord,
            [AnotherTextRecordStruct] = failure,
            [UpperAnotherTextRecordStruct] = ZeroIdNullNameRecord,
            [default] = Failure.Create("Some message")
        };

        var source = AsyncPipeline.Pipe<FlatArray<RecordStruct>, Failure<Unit>>(mapper.Keys.ToFlatArray(), default);

        var option = new PipelineParallelOption
        {
            DegreeOfParallelism = degreeOfParallelism
        };

        var actual = await source.ForwardParallel(
            forwardAsync: (RecordStruct key, CancellationToken _) => Task.FromResult(mapper[key]),
            option: option)
        .ToTask();

        Assert.StrictEqual(failure, actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    public static async Task ForwardParallel_Array_AllResultsAreSuccess_ExpectSuccessArrayValue(
        int? degreeOfParallelism)
    {
        var mapper = new Dictionary<RecordStruct, Result<RecordType?, Failure<Unit>>>
        {
            [SomeTextRecordStruct] = MinusFifteenIdSomeStringNameRecord,
            [AnotherTextRecordStruct] = null,
            [UpperAnotherTextRecordStruct] = ZeroIdNullNameRecord
        };

        var source = AsyncPipeline.Pipe<FlatArray<RecordStruct>, Failure<Unit>>(mapper.Keys.ToFlatArray(), default);

        var option = new PipelineParallelOption
        {
            DegreeOfParallelism = degreeOfParallelism
        };

        var actual = await source.ForwardParallel(
            forwardAsync: (RecordStruct key, CancellationToken _) => Task.FromResult(mapper[key]),
            option: option)
        .ToTask();

        var expected = new FlatArray<RecordType?>(MinusFifteenIdSomeStringNameRecord, null, ZeroIdNullNameRecord);

        Assert.StrictEqual(expected, actual);
    }
}