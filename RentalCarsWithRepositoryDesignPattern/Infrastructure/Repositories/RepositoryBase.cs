using Microsoft.EntityFrameworkCore;
using RentalCarsWithRepositoryDesignPattern.Application.IRepositories;
using RentalCarsWithRepositoryDesignPattern.Infrastructure.Context;

namespace RentalCarsWithRepositoryDesignPattern.Infrastructure.Repositories;

public abstract class RepositoryBase<T>(RentalCarContext rentalCarContext) : IRepositoryBase<T> where T : class
{
    public RentalCarContext Context = rentalCarContext;
    public DbSet<T> Table = rentalCarContext.Set<T>();

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
    public async Task<int> Update(T item)
    {
        try
        {
            Table.Attach(item);
            Context.Entry(item).State = EntityState.Modified;
            var entitiesAdded = await Context.SaveChangesAsync();
            return 1;
        }
        catch
        {
            return 0;
        }
    }
}
