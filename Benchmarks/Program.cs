global using BenchmarkDotNet.Configs;
global using BenchmarkDotNet.Attributes;

using System.Globalization;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Benchmarks;

class Program {
  
  static void Main(string[] args) {
    
    var config = ManualConfig.Create(DefaultConfig.Instance);
    config.SummaryStyle = new SummaryStyle(CultureInfo.CurrentCulture, true, BenchmarkDotNet.Columns.SizeUnit.B, null);
    config.AddDiagnoser(MemoryDiagnoser.Default);

    BenchmarkRunner.Run<StringBenchmarks>(config);
    
    //Console.WriteLine("\n\nFinished, press any key to exit...");
    //Console.ReadKey();
  }
}