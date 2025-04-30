using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Application.IRepositories;
using RentalCarsWithRepositoryDesignPattern.Application.IServices;
using RentalCarsWithRepositoryDesignPattern.Domain.Data;

namespace RentalCarsWithRepositoryDesignPattern.Application.Services;

public class RentalService(IRepositoryBase<Rental> rentalRepository) : IRentalService
{
    public async Task<Rental> Add(RentalCarDto rentalCarDto)
    {
        var rentalCar = new Rental
        {
            IdUserClient = rentalCarDto.IdUserClient,
            IdAutoMobile = rentalCarDto.IdAutoMobile,
            BaseTariff = rentalCarDto.BaseTariff,
            TarifPerHour = rentalCarDto.TarifPerHour,
            DateRent = rentalCarDto.DateRent
        };
        var numberRecordAdded = await rentalRepository.Insert(rentalCar);

        if (numberRecordAdded <= 0)
        {
            throw new ArgumentException($"Car not inserted!");
        }
        return rentalCar;
    }

    public async Task<IEnumerable<Rental>> GetAll()
    {
        var listRentalCars = await rentalRepository.GetAll();
        return listRentalCars;
    }
}
