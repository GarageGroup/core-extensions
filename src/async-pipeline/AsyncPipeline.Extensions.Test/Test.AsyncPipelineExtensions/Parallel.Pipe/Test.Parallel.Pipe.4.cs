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
    public static void PipeParallel_Fourth_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<int?, CancellationToken, Task<RecordStruct>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult<RefType?>(ZeroIdRefType),
                thirdPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (_, _) => Task.FromResult(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallel_Fourth_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(SomeTextRecordStruct),
                secondPipeAsync: (Func<int?, CancellationToken, Task<RefType?>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (_, _) => Task.FromResult(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallel_Fourth_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(SomeTextRecordStruct),
                secondPipeAsync: (_, _) => Task.FromResult<RefType?>(ZeroIdRefType),
                thirdPipeAsync: (Func<int?, CancellationToken, Task<RecordType>>)null!,
                fourthPipeAsync: (_, _) => Task.FromResult(MixedWhiteSpacesString));
    }

    [Fact]
    public static void PipeParallel_Fourth_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult(SomeTextRecordStruct),
                secondPipeAsync: (_, _) => Task.FromResult<RefType?>(ZeroIdRefType),
                thirdPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                fourthPipeAsync: (Func<int?, CancellationToken, Task<string>>)null!);
    }

    [Fact]
    public static void PipeParallel_Fourth_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe<int?>(MinusFifteen, default);

        var actual = _ = source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult(SomeTextRecordStruct),
            secondPipeAsync: (_, _) => Task.FromResult<RefType?>(ZeroIdRefType),
            thirdPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
            fourthPipeAsync: (_, _) => Task.FromResult(MixedWhiteSpacesString));

        var expectedValue = (
            SomeTextRecordStruct,
            (RefType?)ZeroIdRefType,
            PlusFifteenIdLowerSomeStringNameRecord,
            MixedWhiteSpacesString);

        var expected = AsyncPipeline.Pipe(expectedValue, default);

        Assert.StrictEqual(expected, actual);
    }
}