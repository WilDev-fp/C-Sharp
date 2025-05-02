using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Domain.Data;

namespace RentalCarsWithRepositoryDesignPattern.Application.IServices;

public interface IAutomobileService
{
    public Task<Automobile> Add(AutomobileDto car);
    public Task<IEnumerable<Automobile>> GetAll();
    public Task<bool> Delete(long id);
}