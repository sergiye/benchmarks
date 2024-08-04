using BenchmarkDotNet.Attributes;

namespace Benchmarks;

// [MinColumn]
// [MaxColumn]
// [MemoryDiagnoser(false)]
// [HideColumns(new []{"Allocated", "Alloc Ratio"})]
public class LoopBenchmarks {

  [Params(10, 1000, 10000)]
  public int N { get; set; }
  
  private int[] numbers;

  [GlobalSetup]
  public void Setup() {
    numbers = Enumerable.Range(1, N).ToArray();
  }

  // [IterationSetup]
  // public void IterationSetup() {
  //   numbers = Enumerable.Range(1, N).ToArray();
  // }

  [Benchmark]
  public int ForSum() {
    var sum = 0;
    for (var i = 0; i < numbers.Length; i++) {
      sum += numbers[i];
    }
    return sum;
  }

  [Benchmark]
  public int ForLoop() {
    Span<int> span = numbers;
    var length = span.Length;
    var result = 0;
    for (var i = 0; i < length; i++) {
      result += span[i];
    }
    return result;
  }

  [Benchmark]
  public int ForEachSum() {
    var sum = 0;
    foreach (var t in numbers) {
      sum += t;
    }
    return sum;
  }

  [Benchmark(Baseline = true)]
  public int LinqSum() => numbers.Sum();

  // [Benchmark]
  // public bool ArrayLookup() => Numbers.Contains(123);
  
  // [Benchmark]
  // public int WhereSum() {
  //   return numbers.Where(n => n % 2 == 0).Sum();
  // }
  
}