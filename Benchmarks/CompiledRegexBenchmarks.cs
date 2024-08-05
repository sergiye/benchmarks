using System.Text.RegularExpressions;

namespace Benchmarks;

public class CompiledRegexBenchmarks {
    //lang=regex
    private const string Row = "[AA] [54a96b1b-77e3-43d4-8a9b-4ad969690217] [Italien] [Some Company J]";

    private Regex compiledRegex;

    [GlobalSetup]
    public void Setup() => compiledRegex = new Regex(@"\[(?<data>.*?)\]",
        RegexOptions.Compiled, TimeSpan.FromSeconds(1));

    private MatchCollection result;

    [Benchmark]
    public void NonCompiled() => result = Regex.Matches(Row, @"\[(?<data>.*?)\]",
        RegexOptions.None, TimeSpan.FromSeconds(1));

    [Benchmark]
    public void Compiled() => result = compiledRegex!.Matches(Row);
}