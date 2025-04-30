using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Domain.Data;

namespace RentalCarsWithRepositoryDesignPattern.Application.IServices;

public interface IRentalService
{
    public Task<Rental> Add(RentalCarDto a);
    public Task<IEnumerable<Rental>> GetAll();
}