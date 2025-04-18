using RentalCarsWithRepositoryDesignPattern.Domain.Data;

namespace RentalCarsWithRepositoryDesignPattern.Application.IServices;

public interface IAutomobileService
{
    public void Add(Automobile a);
}