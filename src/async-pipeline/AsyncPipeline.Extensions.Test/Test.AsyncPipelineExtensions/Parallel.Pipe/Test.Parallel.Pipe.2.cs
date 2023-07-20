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
    public static void PipeParallel_Two_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<RecordType?, CancellationToken, Task<StructType>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult(ZeroIdRefType));
    }

    [Fact]
    public static void PipeParallel_Two_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(LowerSomeTextStructType),
                secondPipeAsync: (Func<RecordType?, CancellationToken, Task<RefType>>)null!);
    }

    [Fact]
    public static async Task PipeParallel_Two_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe<RecordType?>(PlusFifteenIdLowerSomeStringNameRecord, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult(LowerSomeTextStructType),
            secondPipeAsync: (_, _) => Task.FromResult(ZeroIdRefType))
        .ToTask();

        var expected = (
            LowerSomeTextStructType,
            ZeroIdRefType);

        Assert.StrictEqual(expected, actual);
    }
}