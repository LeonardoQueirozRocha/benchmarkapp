using BenchmarkApp.Console;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<AppBenchmark>();