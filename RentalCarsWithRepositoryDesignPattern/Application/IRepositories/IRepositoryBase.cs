namespace RentalCarsWithRepositoryDesignPattern.Application.IRepositories;

public interface IRepositoryBase<T>
{
    IEnumerable<T> GetAll();
    T GetById(long id);
    bool Insert(T item);
    bool Update(T item);
    bool Delete(long id);
}
