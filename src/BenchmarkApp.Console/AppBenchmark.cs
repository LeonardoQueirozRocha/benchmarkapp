using BenchmarkDotNet.Attributes;

namespace BenchmarkApp.Console;

public class AppBenchmark
{
    private string text = "/";

    [Benchmark]
    public bool FinishWithPlankString()
    {
        return text.EndsWith("/");
    }

    [Benchmark]
    public bool FinishWithPlankChar()
    {
        return text.EndsWith('/');
    }
}