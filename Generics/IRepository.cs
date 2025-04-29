namespace BlogProject.Generics;

public interface IRepository<T> where T : class
{
    void Add(T entity);

    void Update(T entity);
    T? FindById(int id);
    List<T?> ListAll();

    void Remove(T entity);
    void Save();
}
