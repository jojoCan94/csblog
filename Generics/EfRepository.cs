
using BlogProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Generics;

public class EfRepository<T>(BlogContext ctx) : IRepository<T> where T : class
{
    private readonly BlogContext _ctx = ctx;

    public async Task AddAsync(T entity)
    {
        await _ctx.Set<T>()
                   .AddAsync(entity);
    }

    public async Task<T> FindByIdAsync(int id)
    {
        return await _ctx.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> ListAllAsync()
    {
        return await _ctx.Set<T>()
                         .AsNoTracking()
                         .ToListAsync();
    }

    public Task UpdateAsync(T entity)
    {
        _ctx.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(T entity)
    {
        _ctx.Set<T>().Remove(entity);
        return Task.CompletedTask;
    }

    public Task SaveAsync()
    {
        return _ctx.SaveChangesAsync();
    }
}
