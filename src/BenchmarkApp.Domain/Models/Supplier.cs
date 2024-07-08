using BenchmarkApp.Domain.Enums;
using BenchmarkApp.Domain.Models.Base;

namespace BenchmarkApp.Domain.Models;

public class Supplier : Entity
{
    public string? Name { get; set; }
    public string? Document { get; set; }
    public SupplierType? SupplierType { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public Address? Address { get; set; }
    public bool? Active { get; set; }
    public IEnumerable<Product>? Products { get; set; }
}
