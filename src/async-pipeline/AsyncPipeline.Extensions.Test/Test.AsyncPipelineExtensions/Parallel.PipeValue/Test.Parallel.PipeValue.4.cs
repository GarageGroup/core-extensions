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
    public static void PipeParallelValue_Fourth_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<int?, CancellationToken, ValueTask<RecordStruct>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(ZeroIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallelValue_Fourth_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(SomeTextRecordStruct),
                secondPipeAsync: (Func<int?, CancellationToken, ValueTask<RefType?>>)null!,
                thirdPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (_, _) => ValueTask.FromResult(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallelValue_Fourth_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(SomeTextRecordStruct),
                secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(ZeroIdRefType),
                thirdPipeAsync: (Func<int?, CancellationToken, ValueTask<RecordType>>)null!,
                fourthPipeAsync: (_, _) => ValueTask.FromResult(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallelValue_Fourth_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult(SomeTextRecordStruct),
                secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(ZeroIdRefType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (Func<int?, CancellationToken, ValueTask<string>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Fourth_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult(SomeTextRecordStruct),
            secondPipeAsync: (_, _) => ValueTask.FromResult<RefType?>(ZeroIdRefType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
            fourthPipeAsync: (_, _) => ValueTask.FromResult(MixedWhiteSpacesString))
        .ToTask();

        var expected = (
            SomeTextRecordStruct,
            (RefType?)ZeroIdRefType,
            PlusFifteenIdLowerSomeStringNameRecord,
            MixedWhiteSpacesString);

        Assert.StrictEqual(expected, actual);
    }
}