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
    public static void PipeParallel_Seven_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<RecordStruct, CancellationToken, Task<decimal>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => Task.FromResult(AnotherString),
                fourthPipeAsync: (_, _) => Task.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => Task.FromResult<bool?>(true),
                sixthPipeAsync: (_, _) => Task.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => Task.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallel_Seven_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(decimal.One),
                secondPipeAsync: (Func<RecordStruct, CancellationToken, Task<RefType?>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult(AnotherString),
                fourthPipeAsync: (_, _) => Task.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => Task.FromResult<bool?>(true),
                sixthPipeAsync: (_, _) => Task.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => Task.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallel_Seven_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(decimal.One),
                secondPipeAsync: (_, _) => Task.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (Func<RecordStruct, CancellationToken, Task<string>>)null!,
                fourthPipeAsync: (_, _) => Task.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => Task.FromResult<bool?>(true),
                sixthPipeAsync: (_, _) => Task.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => Task.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallel_Seven_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(decimal.One),
                secondPipeAsync: (_, _) => Task.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => Task.FromResult(AnotherString),
                fourthPipeAsync: (Func<RecordStruct, CancellationToken, Task<DateOnly>>)null!,
                fifthPipeAsync: (_, _) => Task.FromResult<bool?>(true),
                sixthPipeAsync: (_, _) => Task.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => Task.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallel_Seven_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(decimal.One),
                secondPipeAsync: (_, _) => Task.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => Task.FromResult(AnotherString),
                fourthPipeAsync: (_, _) => Task.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (Func<RecordStruct, CancellationToken, Task<bool?>>)null!,
                sixthPipeAsync: (_, _) => Task.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (_, _) => Task.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallel_Seven_SixthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(decimal.One),
                secondPipeAsync: (_, _) => Task.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => Task.FromResult(AnotherString),
                fourthPipeAsync: (_, _) => Task.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => Task.FromResult<bool?>(true),
                sixthPipeAsync: (Func<RecordStruct, CancellationToken, Task<StructType>>)null!,
                seventhPipeAsync: (_, _) => Task.FromResult(Array.Empty<long?>()));
    }

    [Fact]
    public static void PipeParallel_Seven_SeventhPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("seventhPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(decimal.One),
                secondPipeAsync: (_, _) => Task.FromResult<RefType?>(MinusFifteenIdRefType),
                thirdPipeAsync: (_, _) => Task.FromResult(AnotherString),
                fourthPipeAsync: (_, _) => Task.FromResult(new DateOnly(2021, 01, 15)),
                fifthPipeAsync: (_, _) => Task.FromResult<bool?>(true),
                sixthPipeAsync: (_, _) => Task.FromResult(LowerSomeTextStructType),
                seventhPipeAsync: (Func<RecordStruct, CancellationToken, Task<long?[]>>)null!);
    }

    [Fact]
    public static void PipeParallel_Seven_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe(SomeTextRecordStruct, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult(decimal.One),
            secondPipeAsync: (_, _) => Task.FromResult<RefType?>(MinusFifteenIdRefType),
            thirdPipeAsync: (_, _) => Task.FromResult(AnotherString),
            fourthPipeAsync: (_, _) => Task.FromResult(new DateOnly(2021, 01, 15)),
            fifthPipeAsync: (_, _) => Task.FromResult<bool?>(true),
            sixthPipeAsync: (_, _) => Task.FromResult(LowerSomeTextStructType),
            seventhPipeAsync: (_, _) => Task.FromResult(Array.Empty<long?>()));

        var expectedValue = (
            decimal.One,
            (RefType?)MinusFifteenIdRefType,
            AnotherString,
            new DateOnly(2021, 01, 15),
            (bool?)true,
            LowerSomeTextStructType,
            Array.Empty<long?>());

        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }
}