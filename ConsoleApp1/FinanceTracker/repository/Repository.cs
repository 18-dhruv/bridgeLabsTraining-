using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using FinanceTracker;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker;
 
public class Repository<TKey,TEntity>:IRepository<TKey,TEntity> where TEntity :class,IEntity<TKey>
{
 private readonly FinanceDbContext context;
 private readonly DbSet<TEntity> dbSet;
 public Repository(FinanceDbContext dbContext)
{
      this.context=dbContext;
      this.dbSet=context.Set<TEntity>();  
}

    public TEntity GetById(int id)
    {
      var entity = dbSet.Find(id);
      if(entity==null)throw new EntityDontExist($"there is no entity associated to this {id}");
         return entity;
    }

    public void RemoveById(int id)
    {
       TEntity entity =GetById(id);
       dbSet.Remove(entity);
       context.SaveChanges();
    }

   public void Add(TEntity entity)
    {
       dbSet.Add(entity);
       context.SaveChanges();
    }

    public List<KeyValuePair<TKey, TEntity>> GetAll()
    {
       return dbSet.AsEnumerable().Select(x => new KeyValuePair<TKey, TEntity>(x.Id, x)).ToList();
    }
}
