using RentalCarsWithRepositoryDesignPattern.Domain.Data;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;

namespace RentalCarsWithRepositoryDesignPattern.Infrastructure.Repositories;

public class RentalRepository (RentalCarContext rentalCarContext) : RepositoryBase<Rental>(rentalCarContext)
{
}
