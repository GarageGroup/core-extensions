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
    public static void PipeParallel_Three_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<string, CancellationToken, Task<RecordType?>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult(MinusFifteenIdRefType));
    }

    [Fact]
    public static void PipeParallel_Three_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<RecordType?>(ZeroIdNullNameRecord),
                secondPipeAsync: (Func<string, CancellationToken, Task<StructType>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult(MinusFifteenIdRefType));
    }

    [Fact]
    public static void PipeParallel_Three_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<RecordType?>(ZeroIdNullNameRecord),
                secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
                thirdPipeAsync: (Func<string, CancellationToken, Task<RefType>>)null!);
    }

    [Fact]
    public static async Task PipeParallel_Three_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe(AnotherString, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<RecordType?>(ZeroIdNullNameRecord),
            secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult(MinusFifteenIdRefType))
        .ToTask();

        var expected = (
            (RecordType?)ZeroIdNullNameRecord,
            SomeTextStructType,
            MinusFifteenIdRefType);

        Assert.StrictEqual(expected, actual);
    }
}