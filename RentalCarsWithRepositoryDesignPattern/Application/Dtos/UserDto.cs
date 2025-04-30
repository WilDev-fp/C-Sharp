using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RentalCarsWithRepositoryDesignPattern.Application.Dtos;

public class UserDto
{
    [Required(ErrorMessage = "Name is required")]
    [DefaultValue("")]
    public string Name { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    [DefaultValue("")]
    public string LastName { get; set; }

    [Range(18, 60, ErrorMessage = "Age must be between 18 and 60.")]
    [DefaultValue(0)]
    public int Age { get; set; }

    [DefaultValue(5000.00)]
    public decimal MinimumBalance { get; set; }

    [Required(ErrorMessage = "TaxIdNumber is required")]
    [DefaultValue("")]
    [StringLength(20, MinimumLength = 5, ErrorMessage = "TaxIdNumber should be between 5 and 20 characters.")]
    public string TaxIdNumber { get; set; }
}
