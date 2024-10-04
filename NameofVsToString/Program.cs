using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public enum SomeEnum
{
    FirstValue,
    SecondValue,
    ThirdValue
}

[MemoryDiagnoser]
public class EnumBenchmark
{
    private const SomeEnum enumValue = SomeEnum.FirstValue;

    [Benchmark]
    public string UsingNameof()
    {
        return nameof(SomeEnum.FirstValue);
    }

    [Benchmark]
    public string UsingToString()
    {
        return enumValue.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Запускаем BenchmarkDotNet
        var summary = BenchmarkRunner.Run<EnumBenchmark>();
    }
}
