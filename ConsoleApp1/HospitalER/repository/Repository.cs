using HospitalER.exception;
using Microsoft.EntityFrameworkCore;

namespace HospitalER.repository;

public class Repository<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : class,IEntity<TKey>
{
    public readonly HospitalDbContext dbContext;
    public readonly DbSet<TEntity> dbSet;

    public Repository(HospitalDbContext dbContext, DbSet<TEntity> dbSet)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public void Add(TKey key, TEntity entity)
    {
        dbSet.Add(entity);
        dbContext.SaveChanges();
    }

    public void Remove(TKey key)
    {
        TEntity entity = GetById(key);
        dbSet.Remove(entity);
        dbContext.SaveChanges();
    }

    public void Update(TKey key)
    {
        throw new NotImplementedException();
    }


    public TEntity GetById(TKey key)
    {
        TEntity entity = dbSet.Find(key);
        
        if (entity == null)
        {
            throw new EntityDontExist($"{key} dont exist");
        }
            
        return entity;
    }

    public List<KeyValuePair<TKey, TEntity>> GetAll()
    {
        return dbSet.AsEnumerable().Select(x => new KeyValuePair<TKey, TEntity>(x.Id, GetById(x.Id))).ToList();
    }
}