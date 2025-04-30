using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Domain.Data;

namespace RentalCarsWithRepositoryDesignPattern.Application.IServices;

public interface IAutomobileService
{
    public Task<Automobile> Add(AutomobileDto a);
    public Task<IEnumerable<Automobile>> GetAll();
}