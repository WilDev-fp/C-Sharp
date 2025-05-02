namespace RentalCarsWithRepositoryDesignPattern.Application.IRepositories;

public interface IRepositoryBase<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(long id);
    Task<int> Insert(T item);
    Task<int> Update(T item);
    Task<int> Delete(long id);
}
