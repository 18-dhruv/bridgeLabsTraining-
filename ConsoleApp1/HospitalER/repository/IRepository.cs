namespace HospitalER.repository;

public interface IRepository<TKey,TEntity> where TEntity:class,IEntity<TKey>
{
    void Add(TKey key, TEntity entity);
    void Remove(TKey key);
    TEntity GetById(TKey key);
    List<KeyValuePair<TKey, TEntity>>GetAll();
}