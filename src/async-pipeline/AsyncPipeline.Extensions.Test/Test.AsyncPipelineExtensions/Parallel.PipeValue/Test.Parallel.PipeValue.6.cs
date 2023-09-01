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
    public static void PipeParallelValue_Six_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<StructType?, CancellationToken, ValueTask<TimeOnly>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<object?>(null),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => ValueTask.FromResult(decimal.MaxValue),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<int?>(MinusOne));
    }

    [Fact]
    public static void PipeParallelValue_Six_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (Func<StructType?, CancellationToken, ValueTask<RecordType>>)null!,
                thirdPipeAsync: (_, _) => ValueTask.FromResult<object?>(null),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => ValueTask.FromResult(decimal.MaxValue),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<int?>(MinusOne));
    }

    [Fact]
    public static void PipeParallelValue_Six_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdNullNameRecord),
                thirdPipeAsync: (Func<StructType?, CancellationToken, ValueTask<object?>>)null!,
                fourthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => ValueTask.FromResult(decimal.MaxValue),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<int?>(MinusOne));
    }

    [Fact]
    public static void PipeParallelValue_Six_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<object?>(null),
                fourthPipeAsync: (Func<StructType?, CancellationToken, ValueTask<RefType>>)null!,
                fifthPipeAsync: (_, _) => ValueTask.FromResult(decimal.MaxValue),
                sixthPipeAsync: (_, _) => ValueTask.FromResult<int?>(MinusOne));
    }

    [Fact]
    public static void PipeParallelValue_Six_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<object?>(null),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdRefType),
                fifthPipeAsync: (Func<StructType?, CancellationToken, ValueTask<decimal>>)null!,
                sixthPipeAsync: (_, _) => ValueTask.FromResult<int?>(MinusOne));
    }

    [Fact]
    public static void PipeParallelValue_Six_SixPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => ValueTask.FromResult<object?>(null),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => ValueTask.FromResult(decimal.MaxValue),
                sixthPipeAsync: (Func<StructType?, CancellationToken, ValueTask<int?>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Six_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => ValueTask.FromResult(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => ValueTask.FromResult<object?>(null),
            fourthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => ValueTask.FromResult(decimal.MaxValue),
            sixthPipeAsync: (_, _) => ValueTask.FromResult<int?>(MinusOne))
        .ToTask();

        var expected = (
            new TimeOnly(15, 32, 51),
            ZeroIdNullNameRecord,
            (object?)null,
            PlusFifteenIdRefType,
            decimal.MaxValue,
            (int?)MinusOne);

        Assert.StrictEqual(expected, actual);
    }
}