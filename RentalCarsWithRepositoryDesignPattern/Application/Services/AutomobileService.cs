using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Application.IRepositories;
using RentalCarsWithRepositoryDesignPattern.Application.IServices;
using RentalCarsWithRepositoryDesignPattern.Domain.Data;
using RentalCarsWithRepositoryDesignPattern.Domain.Enumeration;

namespace RentalCarsWithRepositoryDesignPattern.Application.Services;

public class AutomobileService(IRepositoryBase<Automobile> automobileRepository) : IAutomobileService
{
    public async Task<Automobile> Add(AutomobileDto carDto)
    {
        var car = new Automobile
        {
            NumberPlate = carDto.NumberPlate,
            ExternalColor = (VarnishColor)carDto.ExternalColor,
            IsRented = carDto.IsRented
        };
        var numberRecordAdded = await automobileRepository.Insert(car);

        if (numberRecordAdded <= 0)
        {
            throw new ArgumentException($"Car not inserted!");
        }
        return car;
    }

    public async Task<IEnumerable<Automobile>> GetAll()
    {
        var listCar = await automobileRepository.GetAll();
        return listCar;
    }

    public async Task<bool> Delete(long id) {
        var car = await automobileRepository.GetById(id);

        if (car is null)
        {
            return false;
        }

        var numberRecordDeleted = await automobileRepository.Delete(id);

        if (numberRecordDeleted != 1)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> Update(long id, AutomobileUpdateDto automobileDto)
    {
        var car = await automobileRepository.GetById(id);

        if (car is null)
        {
            return false;
        }

        car.ExternalColor = (VarnishColor)automobileDto.ExternalColor;
        car.IsRented = automobileDto.IsRented;

        var numberRecordUpdated = await automobileRepository.Update(car);

        if (numberRecordUpdated != 1)
        {
            return false;
        }

        return true;
    }
}
