namespace server.Data;

public interface IRepository<T> where T : class
{
    Task Create(T item);
    Task Delete(int id);
    Task<T?> Get(int id);
    Task<List<T>> GetAll();
    Task Update(int id, T item);
}