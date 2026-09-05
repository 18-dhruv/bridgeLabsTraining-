namespace FinanceTracker;

public interface IRepository<TKey,TEntity> where TEntity:class
{
    TEntity GetById(int id);
    void RemoveById(int id);
    void Add(TEntity entity);
    List<KeyValuePair<TKey, TEntity>> GetAll();
}