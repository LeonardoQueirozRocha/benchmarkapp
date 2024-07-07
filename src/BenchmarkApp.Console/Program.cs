using BenchmarkApp.Console.Models;
using BenchmarkDotNet.Running;

var summary = BenchmarkRunner.Run<AppBenchmark>();