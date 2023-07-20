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
    public static void PipeParallel_Array_PipeAsyncIsNull_ExpectArgumentNullException(
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
            _ = source.PipeParallel(
                pipeAsync: (Func<string?, CancellationToken, Task<RecordType>>)null!,
                option: option);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    public static void PipeParallel_Array_InputIsEmpty_ExpectEmptyArrayValue(
        int? degreeOfParallelism)
    {
        var source = AsyncPipeline.Pipe<FlatArray<RefType>>(default, default);

        var option = new PipelineParallelOption
        {
            DegreeOfParallelism = degreeOfParallelism
        };

        var actual = _ = source.PipeParallel(
            pipeAsync: (_, _) => Task.FromResult(SomeString),
            option: option);

        var expected = AsyncPipeline.Pipe<FlatArray<string>>(default, default);

        Assert.StrictEqual(expected, actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    public static void PipeParallel_Array_InputIsNotEmpty_ExpectArrayValue(
        int? degreeOfParallelism)
    {
        var mapper = new Dictionary<RecordStruct, RecordType?>
        {
            [SomeTextRecordStruct] = MinusFifteenIdSomeStringNameRecord,
            [AnotherTextRecordStruct] = null,
            [UpperAnotherTextRecordStruct] = ZeroIdNullNameRecord
        };

        var source = AsyncPipeline.Pipe(mapper.Keys.ToFlatArray(), default);

        var option = new PipelineParallelOption
        {
            DegreeOfParallelism = degreeOfParallelism
        };

        var actual = _ = source.PipeParallel(
            pipeAsync: (RecordStruct key, CancellationToken _) => Task.FromResult(mapper[key]),
            option: option);

        var expected = AsyncPipeline.Pipe(mapper.Values.ToFlatArray(), default);

        Assert.StrictEqual(expected, actual);
    }
}