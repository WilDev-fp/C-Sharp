namespace RentalCarsWithRepositoryDesignPattern.Domain.Data;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public long Age { get; set; }
    public decimal MinimumBalance { get; set; }
    public string TaxIdNumber { get; set; }
}
