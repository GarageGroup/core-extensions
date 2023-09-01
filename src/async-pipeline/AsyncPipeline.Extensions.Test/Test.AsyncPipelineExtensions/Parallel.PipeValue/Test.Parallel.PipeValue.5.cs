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
    public static void PipeParallelValue_Five_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<RecordType, CancellationToken, ValueTask<RefType>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult(false),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<RecordStruct?>(SomeTextRecordStruct),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<StructType?>(LowerSomeTextStructType));
    }

    [Fact]
    public static void PipeParallelValue_Five_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdRefType),
                secondPipeAsync: (Func<RecordType, CancellationToken, ValueTask<bool>>)null!,
                thirdPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<RecordStruct?>(SomeTextRecordStruct),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<StructType?>(LowerSomeTextStructType));
    }

    [Fact]
    public static void PipeParallelValue_Five_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdRefType),
                secondPipeAsync: (_, _) => ValueTask.FromResult(false),
                thirdPipeAsync: (Func<RecordType, CancellationToken, ValueTask<string>>)null!,
                fourthPipeAsync: (_, _) => ValueTask.FromResult<RecordStruct?>(SomeTextRecordStruct),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<StructType?>(LowerSomeTextStructType));
    }

    [Fact]
    public static void PipeParallelValue_Five_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdRefType),
                secondPipeAsync: (_, _) => ValueTask.FromResult(false),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeString),
                fourthPipeAsync: (Func<RecordType, CancellationToken, ValueTask<RecordStruct?>>)null!,
                fifthPipeAsync: (_, _) => ValueTask.FromResult<StructType?>(LowerSomeTextStructType));
    }

    [Fact]
    public static void PipeParallelValue_Five_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdRefType),
                secondPipeAsync: (_, _) => ValueTask.FromResult(false),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<RecordStruct?>(SomeTextRecordStruct),
                fifthPipeAsync: (Func<RecordType, CancellationToken, ValueTask<StructType?>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Five_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdRefType),
            secondPipeAsync: (_, _) => ValueTask.FromResult(false),
            thirdPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeString),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<RecordStruct?>(SomeTextRecordStruct),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<StructType?>(LowerSomeTextStructType))
        .ToTask();

        var expected = (
            ZeroIdRefType,
            false,
            LowerSomeString,
            (RecordStruct?)SomeTextRecordStruct,
            (StructType?)LowerSomeTextStructType);

        Assert.StrictEqual(expected, actual);
    }
}