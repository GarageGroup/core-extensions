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
    public static void PipeParallelValue_Two_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<RecordType?, CancellationToken, ValueTask<StructType>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdRefType));
    }

    [Fact]
    public static void PipeParallelValue_Two_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeTextStructType),
                secondPipeAsync: (Func<RecordType?, CancellationToken, ValueTask<RefType>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Two_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeTextStructType),
            secondPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdRefType))
        .ToTask();

        var expected = (
            LowerSomeTextStructType,
            ZeroIdRefType);

        Assert.StrictEqual(expected, actual);
    }
}