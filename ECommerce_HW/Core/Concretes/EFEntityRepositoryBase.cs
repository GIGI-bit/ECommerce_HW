using ECommerce_HW.Core.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce_HW.Core.Concretes
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private readonly TContext context;

        public EFEntityRepositoryBase(TContext context)
        {
            this.context = context;
        }

        public async Task Add(TEntity entity)
        {
            var addedEn = context.Entry(entity);
            addedEn.State = EntityState.Added;
            await context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            var deleted =context.Entry(entity);
            deleted.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task DeleteList(List<TEntity> entities)
        {
            foreach (var item in entities)
            {
                var deleted = context.Entry(item);
                deleted.State = EntityState.Deleted;
            }
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ?
               await context.Set<TEntity>().ToListAsync() :
               await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
