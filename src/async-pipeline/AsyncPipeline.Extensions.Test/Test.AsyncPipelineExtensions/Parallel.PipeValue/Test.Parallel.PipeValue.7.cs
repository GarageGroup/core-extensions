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
    public static void PipeParallelValue_Seven_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<decimal>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(AnotherString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<bool?>(true),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Seven_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(decimal.One),
                secondPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<RefType?>>)null!,
                thirdPipeAsync: (_, _) => ValueTask.FromResult(AnotherString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<bool?>(true),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Seven_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(decimal.One),
                secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<string>>)null!,
                fourthPipeAsync: (_, _) => ValueTask.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<bool?>(true),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Seven_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(decimal.One),
                secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(AnotherString),
                fourthPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<DateOnly>>)null!,
                fifthPipeAsync: (_, _) => ValueTask.FromResult<bool?>(true),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Seven_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(decimal.One),
                secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(AnotherString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<bool?>>)null!,
                sixthPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Seven_SixthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(decimal.One),
                secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(AnotherString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<bool?>(true),
                sixthPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<StructType>>)null!,
                seventhPipeAsync: (_, _) => ValueTask.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallelValue_Seven_SeventhPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("seventhPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(decimal.One),
                secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(AnotherString),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => ValueTask.FromResult<bool?>(true),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (Func<RecordStruct, CancellationToken, ValueTask<long?[]>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Seven_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult(decimal.One),
            secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(MinusFifteenIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult(AnotherString),
            fourthPipeAsync: (_, _) => ValueTask.FromResult(new DateOnly(2021, 01, 15)),
            fifthPipeAsync: (_, _) => ValueTask.FromResult<bool?>(true),
            sixthPipeAsync: (_, _) => ValueTask.FromResult(LowerSomeTextStructType),
            seventhPipeAsync: (_, _) => ValueTask.FromResult(Array.Empty<long?>()))
        .ToTask();

        var expected = (
            decimal.One,
            (RefType?)MinusFifteenIdRefType,
            AnotherString,
            new DateOnly(2021, 01, 15),
            (bool?)true,
            LowerSomeTextStructType,
            Array.Empty<long?>());

        Assert.StrictEqual(expected, actual);
    }
}