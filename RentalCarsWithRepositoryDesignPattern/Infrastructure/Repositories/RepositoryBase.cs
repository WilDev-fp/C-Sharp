using Microsoft.EntityFrameworkCore;
using RentalCarsWithRepositoryDesignPattern.Application.IRepositories;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;

namespace RentalCarsWithRepositoryDesignPattern.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    public RentalCarContext Context = null;
    public DbSet<T>? Table = null;
    protected RepositoryBase(RentalCarContext rentalCarContext)
    {
        Context = rentalCarContext;
        Table = rentalCarContext.Set<T>();
    }

    public bool Delete(long id)
    {
        T existing = Table.Find(id);
        if (Table.Remove(existing) is not null)
        {
            return true;
        }
        return false;
    }

    public IEnumerable<T> GetAll()
    {
        return [.. Table];
    }

    public T GetById(long id)
    {
        return Table.Find(id);
    }
    public bool Insert(T item)
    {
        if (Table.Add(item) is not null)
        {
            return true;
        }
        return false;
    }
    public bool Update(T item)
    {
        try
        {
            Table.Attach(item);
            Context.Entry(item).State = EntityState.Modified;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public int Save()
    {
        return Context.SaveChanges();
    }
}
