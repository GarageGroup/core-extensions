using System;
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
    public static void PipeParallelValue_ArrayUnit_PipeAsyncIsNull_ExpectArgumentNullException(
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
                pipeAsync: null!,
                option: option);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestData))]
    public static async Task PipeParallelValue_ArrayUnit_InputIsEmpty_ExpectUnit(
        PipelineParallelOption? option)
    {
        var source = AsyncPipeline.Pipe<FlatArray<RefType>>(default, default);

        var actual = await source.PipeParallelValue(
            pipeAsync: (_, _) => default,
            option: option)
        .ToTask();

        var expected = default(Unit);

        Assert.StrictEqual(expected, actual);
    }

    [Theory]
    [MemberData(nameof(PipelineParallelOptionTestData))]
    public static async Task PipeParallelValue_ArrayUnit_InputIsNotEmpty_ExpectUnit(
        PipelineParallelOption? option)
    {
        FlatArray<RecordStruct> input = [SomeTextRecordStruct, AnotherTextRecordStruct, UpperAnotherTextRecordStruct];
        var source = AsyncPipeline.Pipe(input, default);

        var actual = await source.PipeParallelValue(
            pipeAsync: (key, _) => default,
            option: option)
        .ToTask();

        var expected = default(Unit);

        Assert.StrictEqual(expected, actual);
    }
}