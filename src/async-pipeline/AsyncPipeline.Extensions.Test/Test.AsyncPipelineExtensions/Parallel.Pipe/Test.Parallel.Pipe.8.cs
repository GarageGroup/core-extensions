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
    public static void PipeParallel_Eight_FirstPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("firstPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (Func<RefType, CancellationToken, Task<string?>>)null!,
                secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult(false),
                seventhPipeAsync: (_, _) => Task.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Eight_SecondPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("secondPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<string?>(SomeString),
                secondPipeAsync: (Func<RefType, CancellationToken, Task<StructType?>>)null!,
                thirdPipeAsync: (_, _) => Task.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult(false),
                seventhPipeAsync: (_, _) => Task.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Eight_ThirdPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("thirdPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
                thirdPipeAsync: (Func<RefType, CancellationToken, Task<byte?>>)null!,
                fourthPipeAsync: (_, _) => Task.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult(false),
                seventhPipeAsync: (_, _) => Task.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Eight_FourthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fourthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult(byte.MaxValue),
                fourthPipeAsync: (Func<RefType, CancellationToken, Task<DateTimeKind?>>)null!,
                fifthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult(false),
                seventhPipeAsync: (_, _) => Task.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Eight_FifthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("fifthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (Func<RefType, CancellationToken, Task<RecordType>>)null!,
                sixthPipeAsync: (_, _) => Task.FromResult(false),
                seventhPipeAsync: (_, _) => Task.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Eight_SixthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("sixthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (Func<RefType, CancellationToken, Task<bool>>)null!,
                seventhPipeAsync: (_, _) => Task.FromResult(double.Epsilon),
                eighthPipeAsync: (_, _) => Task.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Eight_SeventhPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("seventhPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult(false),
                seventhPipeAsync: (Func<RefType, CancellationToken, Task<double>>)null!,
                eighthPipeAsync: (_, _) => Task.FromResult<long?>(long.MinValue));
    }

    [Fact]
    public static void PipeParallel_Eight_EighthPipeAsyncIsNull_ExpectArgumentNullException()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.Equal("eighthPipeAsync", ex.ParamName);

        void Test()
            =>
            _ = source.PipeParallel(
                firstPipeAsync: (_, _) => Task.FromResult<string?>(SomeString),
                secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
                thirdPipeAsync: (_, _) => Task.FromResult(byte.MaxValue),
                fourthPipeAsync: (_, _) => Task.FromResult<DateTimeKind?>(DateTimeKind.Utc),
                fifthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
                sixthPipeAsync: (_, _) => Task.FromResult(false),
                seventhPipeAsync: (_, _) => Task.FromResult(double.Epsilon),
                eighthPipeAsync: (Func<RefType, CancellationToken, Task<long?>>)null!);
    }

    [Fact]
    public static async Task PipeParallel_Eight_NonOfPipeFunctionsIsNull_ExpectTupleValue()
    {
        var source = AsyncPipeline.Pipe(PlusFifteenIdRefType, default);

        var actual = await source.PipeParallel(
            firstPipeAsync: (_, _) => Task.FromResult<string?>(SomeString),
            secondPipeAsync: (_, _) => Task.FromResult(SomeTextStructType),
            thirdPipeAsync: (_, _) => Task.FromResult(byte.MaxValue),
            fourthPipeAsync: (_, _) => Task.FromResult<DateTimeKind?>(DateTimeKind.Utc),
            fifthPipeAsync: (_, _) => Task.FromResult(PlusFifteenIdLowerSomeStringNameRecord),
            sixthPipeAsync: (_, _) => Task.FromResult(false),
            seventhPipeAsync: (_, _) => Task.FromResult(double.Epsilon),
            eighthPipeAsync: (_, _) => Task.FromResult<long?>(long.MinValue))
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