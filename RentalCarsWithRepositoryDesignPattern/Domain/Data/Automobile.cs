using RentalCarsWithRepositoryDesignPattern.Domain.Enumeration;

namespace RentalCarsWithRepositoryDesignPattern.Domain.Data;

public class Automobile
{
    public long Id { get; set; }
    public string NumberPlate { get; set; }
    public VarnishColor ExternalColor { get; set; }
    public bool IsRented { get; set; } = false;
}
