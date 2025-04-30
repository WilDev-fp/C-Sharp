using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentalCarsWithRepositoryDesignPattern.Application.Dtos;

public class AutomobileDto
{
    [Required(ErrorMessage = "NumberPlate is required")]
    [DefaultValue("")]
    public string NumberPlate { get; set; }

    [Range(1, 4, ErrorMessage = "ExternalColor must be between 1 and 4.")]
    [DefaultValue(0)]
    public int ExternalColor { get; set; }

    [DefaultValue(false)]
    public bool IsRented { get; set; }
}
