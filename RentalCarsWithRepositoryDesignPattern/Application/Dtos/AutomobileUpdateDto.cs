using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RentalCarsWithRepositoryDesignPattern.Application.Dtos;

public class AutomobileUpdateDto
{
    [Range(1, 4, ErrorMessage = "ExternalColor must be between 1 and 4.")]
    [DefaultValue(0)]
    public int ExternalColor { get; set; }

    [DefaultValue(false)]
    public bool IsRented { get; set; }
}
