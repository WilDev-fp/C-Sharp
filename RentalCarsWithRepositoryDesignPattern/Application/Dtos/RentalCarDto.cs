using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalCarsWithRepositoryDesignPattern.Application.Dtos;

public class RentalCarDto
{
    public long IdAutoMobile { get; set; }
    public long IdUserClient { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateRent { get; set; }

    [DefaultValue(10.00)]
    public decimal TarifPerHour { get; set; }

    [DefaultValue(250.00)]
    public decimal BaseTariff { get; set; }
}
