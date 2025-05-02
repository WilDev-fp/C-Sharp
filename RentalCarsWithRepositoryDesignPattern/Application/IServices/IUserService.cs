using RentalCarsWithRepositoryDesignPattern.Application.Dtos;
using RentalCarsWithRepositoryDesignPattern.Domain.Data;

namespace RentalCarsWithRepositoryDesignPattern.Application.IServices;

public interface IUserService
{
    public Task<User> Add(UserDto a);
    public Task<IEnumerable<User>> GetAll();
    public Task<bool> Delete(long id);
}