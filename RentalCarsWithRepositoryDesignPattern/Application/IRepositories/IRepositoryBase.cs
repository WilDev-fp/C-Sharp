namespace RentalCarsWithRepositoryDesignPattern.Application.IRepositories;

public interface IRepositoryBase<T>
{
    Task<IEnumerable<T>> GetAll();
    T GetById(long id);
    Task<int> Insert(T item);
    bool Update(T item);
    bool Delete(long id);
}
