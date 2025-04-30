namespace RentalCarsWithRepositoryDesignPattern.Domain.Data;

public class Rental
{
    public long Id { get; set; }
    public long IdAutoMobile { get; set; }
    public long IdUserClient { get; set; }
    public DateTime DateRent { get; set; } = DateTime.Now;
    public DateTime? DateReturn { get; set; }
    public decimal TarifPerHour { get; set; } = 0m;
    public decimal BaseTariff { get; set; } = 0m;
}
