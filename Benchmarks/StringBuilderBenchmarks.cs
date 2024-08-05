using System.Text;

namespace Benchmarks;

public class StringBuilderBenchmarks {
    
    private ICollection<string> testData = Array.Empty<string>();

    [Params(1, 2, 100, 1000)] public int Size { get; set; }

    [GlobalSetup]
    public void Setup() {
        var list = new List<string>(Size);

        for (int i = 0; i < Size; i++) {
            list.Add($"ENG{i:d3}");
        }

        testData = list;
    }

    [Benchmark]
    public void WithCapacity() {
        var capacity = testData.Count * (6 + Environment.NewLine.Length);

        var stringBuilder = new StringBuilder(capacity);

        foreach (var item in testData) {
            stringBuilder.AppendLine(item);
        }
    }

    [Benchmark]
    public void WithoutCapacity() {
        var stringBuilder = new StringBuilder();

        foreach (var item in testData) {
            stringBuilder.AppendLine(item);
        }
    }
}
