namespace Dashboard.Repository;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T Get(int id);
    void Update(T obj);
    void Save();
    T? GetInclude( string include);
}