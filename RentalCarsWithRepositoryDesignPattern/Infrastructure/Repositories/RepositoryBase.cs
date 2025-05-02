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

    public async Task<int> Delete(long id)
    {
        T existing = await Table.FindAsync(id);

        if (Table.Remove(existing) is not null)
        {
            var entitiesDeleted = await Context.SaveChangesAsync();
            return entitiesDeleted;
        }
        return 0;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Table.ToListAsync();
    }

    public async Task<T> GetById(long id)
    {
        return await Table.FindAsync(id);
    }
    public async Task<int> Insert(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        Table.Add(item);
        var entitiesAdded = await Context.SaveChangesAsync();
        return entitiesAdded;
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
}
