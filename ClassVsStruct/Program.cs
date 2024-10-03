using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace PerformanceComparison
{
    // Person model as class
    public class PersonClass
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }

        public PersonClass(int id, string lastName, string firstName, int age)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Age = age;
        }
    }
    public struct PersonStruct
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }

        public PersonStruct(int id, string lastName, string firstName, int age)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Age = age;
        }
    }

    // Benchmark class for comparison
    [MemoryDiagnoser]
    public class ModelPerformanceComparison
    {
        private const int _iterations = 1000000;

        // Benchmark for class model
        [Benchmark]
        public void ClassModelTest()
        {
            for (int i = 0; i < _iterations; i++)
            {
                var person = new PersonClass(i, "Doe", "John", 30);
            }
        }

        // Benchmark for struct model
        [Benchmark]
        public void StructModelTest()
        {
            for (int i = 0; i < _iterations; i++)
            {
                var person = new PersonStruct(i, "Doe", "John", 30);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ModelPerformanceComparison>();
            Console.WriteLine(summary);
        }
    }
}
