using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Application.IRepositories;
using RentalCarsWithRepositoryDesignPattern.Application.IServices;
using RentalCarsWithRepositoryDesignPattern.Domain.Data;

namespace RentalCarsWithRepositoryDesignPattern.Application.Services;

public class UserService(IRepositoryBase<User> userRepository) : IUserService
{
    public async Task<User> Add(UserDto userDto)
    {
        var user = new User
        {
            Age = userDto.Age,
            LastName = userDto.LastName,
            MinimumBalance = userDto.MinimumBalance,
            Name = userDto.Name,
            TaxIdNumber = userDto.TaxIdNumber
        };
        var numberRecordAdded = await userRepository.Insert(user);

        if (numberRecordAdded <= 0)
        {
            throw new ArgumentException($"Car not inserted!");
        }

        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        var listUser = await userRepository.GetAll();
        return listUser;
    }
}
