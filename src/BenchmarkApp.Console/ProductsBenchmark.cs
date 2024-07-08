using System.Globalization;
using BenchmarkApp.Domain.Models;
using BenchmarkDotNet.Attributes;
using CsvHelper;
using CsvHelper.Configuration;

namespace BenchmarkApp.Console;

[MemoryDiagnoser]
public class ProductsBenchmark
{
    private List<Product>? products;

    [GlobalSetup]
    public void Setup()
    {
        var configuration = new CsvConfiguration
        {
            CultureInfo = CultureInfo.InvariantCulture,
        };

        var filePath = "/Users/leonardoqueirozrocha/Dev/desenvolvedorio/benchmarkapp/src/BenchmarkApp.Console/Files/products.csv";
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, configuration);
        products = csv.GetRecords<Product>().ToList();
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
            .Where(product => product.Active)
            .ToList();

        return result;
    }

    [Benchmark]
    public List<Product> EfficientSorting()
    {
        return products!
            .Where(product => product.Active)
            .OrderBy(product => product.Name!.ToUpper())
            .ToList();
    }
}