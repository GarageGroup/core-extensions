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
    public static void PipeParallelValue_Eight_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (Func<RefType, CancellationToken, ValueTask<string?>>)null!,
                secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(false),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => ValueTask.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallelValue_Eight_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<string?>(SomeString),
                secondPipeAsync: (Func<RefType, CancellationToken, ValueTask<StructType?>>)null!,
                thirdPipeAsync: (_, _) => ValueTask.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(false),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => ValueTask.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallelValue_Eight_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
                thirdPipeAsync: (Func<RefType, CancellationToken, ValueTask<byte?>>)null!,
                fourthPipeAsync: (_, _) => ValueTask.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(false),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => ValueTask.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallelValue_Eight_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(byte.MaxValue),
                fourthPipeAsync: (Func<RefType, CancellationToken, ValueTask<DateTimeKind?>>)null!,
                fifthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(false),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => ValueTask.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallelValue_Eight_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (Func<RefType, CancellationToken, ValueTask<RecordType>>)null!,
                sixthPipeAsync: (_, _) => ValueTask.FromResult(false),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => ValueTask.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallelValue_Eight_SixthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (Func<RefType, CancellationToken, ValueTask<bool>>)null!,
                seventhPipeAsync: (_, _) => ValueTask.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => ValueTask.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallelValue_Eight_SeventhPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("seventhPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(false),
                seventhPipeAsync: (Func<RefType, CancellationToken, ValueTask<double>>)null!,
                eighthPipeAsync: (_, _) => ValueTask.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallelValue_Eight_EighthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("eighthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallelValue(
                firstPipeAsync: (_, _) => ValueTask.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => ValueTask.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => ValueTask.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => ValueTask.FromResult(false),
                seventhPipeAsync: (_, _) => ValueTask.FromResult(double.Epsilon),
                eighthPipeAsync: (Func<RefType, CancellationToken, ValueTask<long?>>)null!);
    }

    [Fact]
    public static async Task PipeParallelValue_Eight_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallelValue(
            firstPipeAsync: (_, _) => ValueTask.FromResult<string?>(SomeString),
            secondPipeAsync: (_, _) => ValueTask.FromResult(SomeTextStructType),
            thirdPipeAsync: (_, _) => ValueTask.FromResult(byte.MaxValue),
            fourthPipeAsync: (_, _) => ValueTask.FromResult<DateTimeKind?>(DateTimeKind.Utc),
            fifthPipeAsync: (_, _) => ValueTask.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
            sixthPipeAsync: (_, _) => ValueTask.FromResult(false),
            seventhPipeAsync: (_, _) => ValueTask.FromResult(double.Epsilon),
            eighthPipeAsync: (_, _) => ValueTask.FromResult<long?>(long.MinValue))
        .ToTask();

        var expected = (
            (string?)SomeString,
            SomeTextStructType,
            byte.MaxValue,
            (DateTimeKind?)DateTimeKind.Utc,
            PlusFifteenIdLowerSomeStringNameRecord,
            false,
            double.Epsilon,
            (long?)long.MinValue);

        Assert.StrictEqual(expected, actual);
    }
}