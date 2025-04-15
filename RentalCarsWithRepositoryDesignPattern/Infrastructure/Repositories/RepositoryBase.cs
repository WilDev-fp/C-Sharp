using RentalCarsWithRepositoryDesignPattern.Application.IRepositories;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;

namespace RentalCarsWithRepositoryDesignPattern.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
{
    protected RepositoryBase(RentalCarContext rentalCarContext)
    {
    }

    public abstract bool Delete(long id);
    public abstract IEnumerable<T> GetAll();
    public abstract T GetById(long id);
    public abstract bool Insert(T item);
    public abstract bool Update(T item);
}
