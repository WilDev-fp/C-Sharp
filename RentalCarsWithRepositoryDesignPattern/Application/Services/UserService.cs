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

    public async Task<bool> Delete(long id)
    {
        var user = await userRepository.GetById(id);
        if (user is null)
        {
            return false;
        }

        var numberRecordDeleted = await userRepository.Delete(id);

        if (numberRecordDeleted != 1)
        {
            return false;
        }

        return true;
    }

    public async Task<bool> Update(long id, UserUpdateDto userDto)
    {
        var user = await userRepository.GetById(id);
        var isUserWithoutChanges = true;

        if (user is null)
        {
            return false;
        }

        if (userDto.Name?.Length > 1)
        {
            user.Name = userDto.Name;
            isUserWithoutChanges = false;
        }

        if (userDto.Age >= 18 && userDto.Age <= 60)
        {
            user.Age = userDto.Age;
            isUserWithoutChanges = false;
        }

        if (userDto.MinimumBalance > 0)
        {
            user.MinimumBalance = userDto.MinimumBalance;
            isUserWithoutChanges = false;
        }

        if (userDto.LastName?.Length > 1)
        {
            user.LastName = userDto.LastName;
            isUserWithoutChanges = false;
        }

        if (userDto.TaxIdNumber?.Length > 1)
        {
            user.TaxIdNumber = userDto.TaxIdNumber;
            isUserWithoutChanges = false;
        }

        if (isUserWithoutChanges)
        {
            return false;
        }

        var numberRecordUpdated = await userRepository.Update(user);

        if (numberRecordUpdated != 1)
        {
            return false;
        }

        return true;
    }
}
