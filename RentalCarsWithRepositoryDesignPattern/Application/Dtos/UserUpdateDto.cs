using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RentalCarsWithRepositoryDesignPattern.Application.Dtos;

public class UserUpdateDto
{
    [DefaultValue("")]
    public string? Name { get; set; }

    [DefaultValue("")]
    public string? LastName { get; set; }

    [DefaultValue(0)]
    public int Age { get; set; }

    [DefaultValue(0)]
    public decimal MinimumBalance { get; set; }

    [DefaultValue("")]
    public string? TaxIdNumber { get; set; }
}
