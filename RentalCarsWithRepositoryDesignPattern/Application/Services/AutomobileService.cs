using RentalCarsWithRepositoryDesignPattern.Application.IRepositories;
using RentalCarsWithRepositoryDesignPattern.Application.IServices;
using RentalCarsWithRepositoryDesignPattern.Domain.Data;

namespace RentalCarsWithRepositoryDesignPattern.Application.Services;

public class AutomobileService(IRepositoryBase<Automobile> automobileRepository) : IAutomobileService
{
    public void Add(Automobile car)
    {
        automobileRepository.Insert(car);
    }
}
