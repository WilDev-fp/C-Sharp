using RentalCarsWithRepositoryDesignPattern.Domain.Data;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;

namespace RentalCarsWithRepositoryDesignPattern.Infrastructure.Repositories;

public class UserRepository (RentalCarContext rentalCarContext) : RepositoryBase<User>(rentalCarContext)
{
}
