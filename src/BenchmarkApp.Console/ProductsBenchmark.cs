using BenchmarkApp.Domain.Models;
using BenchmarkDotNet.Attributes;
using CsvHelper;

namespace BenchmarkApp.Console;

[MemoryDiagnoser]
public class ProductsBenchmark
{
    private IEnumerable<Product>? products;

    [GlobalSetup]
    public void Setup()
    {
        var filePath = string.Empty;
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader);
        products = csv.GetRecords<Product>();
    }

    [Benchmark]
    public List<Product> InefficientSorting()
    {
        var result = products!
            .Select(product =>
            {
                product.Name = product.Name!.ToUpper();
                return product;
            })
            .OrderBy(product => product.Name)
            .Where(product => product.Active!.Value)
            .ToList();

        return result;
    }

    [Benchmark]
    public List<Product> EfficientSorting()
    {
        return products!
            .Where(product => product.Active!.Value)
            .OrderBy(product => product.Name!.ToUpper())
            .ToList();
    }
}