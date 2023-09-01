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
    public static void PipeParallelValue_Three_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<string, CancellationToken, ValueTask<RecordType?>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(MinusFifteenIdRefType));
    }

    [Fact]
    public static void PipeParallelValue_Three_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<RecordType?>(ZeroIdNullNameRecord),
                secondPipeAsync: (Func<string, CancellationToken, ValueTask<StructType>>)null!,
                thirdPipeAsync: (_, _) => ValueTask.FromResult(MinusFifteenIdRefType));
    }

    [Fact]
    public static void PipeParallelValue_Three_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<RecordType?>(ZeroIdNullNameRecord),
                secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
                thirdPipeAsync: (Func<string, CancellationToken, ValueTask<RefType>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Three_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<RecordType?>(ZeroIdNullNameRecord),
            secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult(MinusFifteenIdRefType))
        .ToTask();

        var expected = (
            (RecordType?)ZeroIdNullNameRecord,
            SomeTextStructType,
            MinusFifteenIdRefType);

        Assert.StrictEqual(expected, actual);
    }
}