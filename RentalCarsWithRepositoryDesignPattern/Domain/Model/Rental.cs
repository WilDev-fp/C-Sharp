namespace RentalCarsWithRepositoryDesignPattern.Domain.Model;

public class Rental
{
    public long Id { get; set; }
    public long IdAutoMobile { get; set; }
    public long IdUserClient { get; set; }
    public DateTime? DateRent { get; set; }
    public DateTime? DateReturn { get; set; }
    public decimal TarifPerHourf { get; set; } = 0m;
    public decimal BaseTariff { get; set; } = 0m;
}
