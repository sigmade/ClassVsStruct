using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

[MemoryDiagnoser]
public class ForeachBenchmark
{
    private List<Person> personList;
    private IEnumerable<Person> personEnumerable;

    [GlobalSetup]
    public void Setup()
    {
        personList = new List<Person>();
        for (int i = 0; i < 10000; i++)
        {
            personList.Add(new Person { Name = $"Person {i}", Age = i });
        }

        personEnumerable = personList.AsEnumerable();
    }

    [Benchmark]
    public void ForeachIEnumerable()
    {

        foreach (var person in personEnumerable.ToList())
        {
            // Имитируем некую логику обработки
            var name = person.Name;
            var age = person.Age;
        }
    }

    [Benchmark]
    public void ForeachList()
    {
        foreach (var person in personList)
        {
            // Имитируем некую логику обработки
            var name = person.Name;
            var age = person.Age;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Запускаем BenchmarkDotNet для сравнения
        var summary = BenchmarkRunner.Run<ForeachBenchmark>();
    }
}
