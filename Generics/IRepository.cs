namespace BlogProject.Generics;

public interface IRepository<T> where T : class
{
Task AddAsync(T entity);
Task<T> FindByIdAsync(int id);
Task<List<T>> ListAllAsync();
Task UpdateAsync(T entity);
Task RemoveAsync(T entity);
Task SaveAsync();
}
