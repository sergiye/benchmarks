namespace Benchmarks;

public class StringBenchmarks {
    
    [Params(10, 1000, 10000)] public int Size { get; set; }

    [GlobalSetup]
    public void Setup() {
    }

    [Benchmark]
    public List<string> StringInterpolation() {
      var list = new List<string>(Size);
      for (int i = 0; i < Size; i++) {
        list.Add($" AND (c.[ReplicationSource] = {i} OR c.[ReplicationTarget] = {i})");
      }
      return list;
    }

    [Benchmark]
    public List<string> StringFormat() {
      var list = new List<string>(Size);
      for (int i = 0; i < Size; i++) {
        list.Add(string.Format(" AND (c.[ReplicationSource] = {0} OR c.[ReplicationTarget] = {0})", i));
      }
      return list;
    }
}