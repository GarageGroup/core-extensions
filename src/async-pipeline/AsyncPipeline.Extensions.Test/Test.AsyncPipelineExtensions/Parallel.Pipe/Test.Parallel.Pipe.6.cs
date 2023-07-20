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
    public static void PipeParallel_Six_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<StructType?, CancellationToken, Task<TimeOnly>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => Task.FromResult<object?>(null),
                fourthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => Task.FromResult(decimal.MaxValue),
                sixthPipeAsync: (_, _) => Task.FromResult<int?>(MinusOne));
    }

    [Fact]
    public static void PipeParallel_Six_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (Func<StructType?, CancellationToken, Task<RecordType>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult<object?>(null),
                fourthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => Task.FromResult(decimal.MaxValue),
                sixthPipeAsync: (_, _) => Task.FromResult<int?>(MinusOne));
    }

    [Fact]
    public static void PipeParallel_Six_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => Task.FromResult(ZeroIdNullNameRecord),
                thirdPipeAsync: (Func<StructType?, CancellationToken, Task<object?>>)null!,
                fourthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => Task.FromResult(decimal.MaxValue),
                sixthPipeAsync: (_, _) => Task.FromResult<int?>(MinusOne));
    }

    [Fact]
    public static void PipeParallel_Six_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => Task.FromResult(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => Task.FromResult<object?>(null),
                fourthPipeAsync: (Func<StructType?, CancellationToken, Task<RefType>>)null!,
                fifthPipeAsync: (_, _) => Task.FromResult(decimal.MaxValue),
                sixthPipeAsync: (_, _) => Task.FromResult<int?>(MinusOne));
    }

    [Fact]
    public static void PipeParallel_Six_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => Task.FromResult(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => Task.FromResult<object?>(null),
                fourthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdRefType),
                fifthPipeAsync: (Func<StructType?, CancellationToken, Task<decimal>>)null!,
                sixthPipeAsync: (_, _) => Task.FromResult<int?>(MinusOne));
    }

    [Fact]
    public static void PipeParallel_Six_SixPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(new TimeOnly(15, 32, 51)),
                secondPipeAsync: (_, _) => Task.FromResult(ZeroIdNullNameRecord),
                thirdPipeAsync: (_, _) => Task.FromResult<object?>(null),
                fourthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdRefType),
                fifthPipeAsync: (_, _) => Task.FromResult(decimal.MaxValue),
                sixthPipeAsync: (Func<StructType?, CancellationToken, Task<int?>>)null!);
    }

    [Fact]
    public static async Task PipeParallel_Six_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe<StructType?>(SomeTextStructType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult(new TimeOnly(15, 32, 51)),
            secondPipeAsync: (_, _) => Task.FromResult(ZeroIdNullNameRecord),
            thirdPipeAsync: (_, _) => Task.FromResult<object?>(null),
            fourthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdRefType),
            fifthPipeAsync: (_, _) => Task.FromResult(decimal.MaxValue),
            sixthPipeAsync: (_, _) => Task.FromResult<int?>(MinusOne))
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