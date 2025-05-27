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
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [0])]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [1])]
    [MemberData(nameof(PipelineParallelOptionTestDataWithCount), [int.MaxValue])]
    public static async Task PipeParallelValue_Array_ExpectArrayValue(
        PipelineParallelOption? option, int count)
    {
        var mapper = new Dictionary<RecordStruct, RecordType?>
        {
            [SomeTextRecordStruct] = MinusFifteenIdSomeStringNameRecord,
            [AnotherTextRecordStruct] = null,
            [UpperAnotherTextRecordStruct] = ZeroIdNullNameRecord
        };

        var source = AsyncPipeline.Pipe(mapper.Keys.ToFlatArray().Take(count), default);

        var actual = await source.PipeParallelValue(
            pipeAsync: (key, _) => ValueTask.FromResult(mapper[key]),
            option: option)
        .ToTask();

        var expected = mapper.Values.ToFlatArray();

        Assert.StrictEqual(expected.Take(count), actual);
    }
}