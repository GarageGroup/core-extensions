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
    public static void PipeParallel_Five_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<RecordType, CancellationToken, Task<RefType>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult(false),
                thirdPipeAsync: (_, _) => Task.FromResult(LowerSomeString),
                fourthPipeAsync: (_, _) => Task.FromResult<RecordStruct?>(SomeTextRecordStruct),
                fifthPipeAsync: (_, _) => Task.FromResult<StructType?>(LowerSomeTextStructType));
    }

    [Fact]
    public static void PipeParallel_Five_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(ZeroIdRefType),
                secondPipeAsync: (Func<RecordType, CancellationToken, Task<bool>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult(LowerSomeString),
                fourthPipeAsync: (_, _) => Task.FromResult<RecordStruct?>(SomeTextRecordStruct),
                fifthPipeAsync: (_, _) => Task.FromResult<StructType?>(LowerSomeTextStructType));
    }

    [Fact]
    public static void PipeParallel_Five_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(ZeroIdRefType),
                secondPipeAsync: (_, _) => Task.FromResult(false),
                thirdPipeAsync: (Func<RecordType, CancellationToken, Task<string>>)null!,
                fourthPipeAsync: (_, _) => Task.FromResult<RecordStruct?>(SomeTextRecordStruct),
                fifthPipeAsync: (_, _) => Task.FromResult<StructType?>(LowerSomeTextStructType));
    }

    [Fact]
    public static void PipeParallel_Five_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(ZeroIdRefType),
                secondPipeAsync: (_, _) => Task.FromResult(false),
                thirdPipeAsync: (_, _) => Task.FromResult(LowerSomeString),
                fourthPipeAsync: (Func<RecordType, CancellationToken, Task<RecordStruct?>>)null!,
                fifthPipeAsync: (_, _) => Task.FromResult<StructType?>(LowerSomeTextStructType));
    }

    [Fact]
    public static void PipeParallel_Five_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(ZeroIdRefType),
                secondPipeAsync: (_, _) => Task.FromResult(false),
                thirdPipeAsync: (_, _) => Task.FromResult(LowerSomeString),
                fourthPipeAsync: (_, _) => Task.FromResult<RecordStruct?>(SomeTextRecordStruct),
                fifthPipeAsync: (Func<RecordType, CancellationToken, Task<StructType?>>)null!);
    }

    [Fact]
    public static void PipeParallel_Five_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe(MinusFifteenIdNullNameRecord, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult(ZeroIdRefType),
            secondPipeAsync: (_, _) => Task.FromResult(false),
            thirdPipeAsync: (_, _) => Task.FromResult(LowerSomeString),
            fourthPipeAsync: (_, _) => Task.FromResult<RecordStruct?>(SomeTextRecordStruct),
            fifthPipeAsync: (_, _) => Task.FromResult<StructType?>(LowerSomeTextStructType));

        var expectedValue = (
            ZeroIdRefType,
            false,
            LowerSomeString,
            (RecordStruct?)SomeTextRecordStruct,
            (StructType?)LowerSomeTextStructType);

        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }
}