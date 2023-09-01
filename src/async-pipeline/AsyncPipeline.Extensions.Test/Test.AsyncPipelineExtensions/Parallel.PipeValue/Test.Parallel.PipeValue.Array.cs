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
    public static void PipeParallelValue_Array_PipeAsyncIsNull_ExpectArgumentNullException(
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
                pipeAsync: (Func<string?, CancellationToken, ValueTask<RecordType>>)null!,
                option: option);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestData))]
    public static async Task PipeParallelValue_Array_InputIsEmpty_ExpectEmptyArrayValue(
        PipelineParallelOption? option)
    {
        var source = AsyncPipeline.Pipe<FlatArray<RefType>>(default, default);

        var actual = await source.PipeParallelValue(
            pipeAsync: (_, _) => ValueTask.FromResult(SomeString),
            option: option)
        .ToTask();

        var expected = default(FlatArray<string>);

        Assert.StrictEqual(expected, actual);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestData))]
    public static async Task PipeParallelValue_Array_InputIsNotEmpty_ExpectArrayValue(
        PipelineParallelOption? option)
    {
        var mapper = new Dictionary<RecordStruct, RecordType?>
        {
            [SomeTextRecordStruct] = MinusFifteenIdSomeStringNameRecord,
            [AnotherTextRecordStruct] = null,
            [UpperAnotherTextRecordStruct] = ZeroIdNullNameRecord
        };

        var source = AsyncPipeline.Pipe(mapper.Keys.ToFlatArray(), default);

        var actual = await source.PipeParallelValue(
            pipeAsync: (RecordStruct key, CancellationToken _) => ValueTask.FromResult(mapper[key]),
            option: option)
        .ToTask();

        var expected = mapper.Values.ToFlatArray();

        Assert.StrictEqual(expected, actual);
    }
}