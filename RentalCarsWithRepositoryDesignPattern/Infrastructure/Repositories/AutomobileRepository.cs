using RentalCarsWithRepositoryDesignPattern.Domain.Data;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;

namespace RentalCarsWithRepositoryDesignPattern.Infrastructure.Repositories;

public class AutomobileRepository(RentalCarContext rentalCarContext) : RepositoryBase<Automobile>(rentalCarContext)
{
}
