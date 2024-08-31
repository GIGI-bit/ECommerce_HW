using System.Linq.Expressions;

namespace ECommerce_HW.Core.Abstraction
{
    public interface IEntityRepository<T> where T:class ,IEntity,new()
    {
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        Task DeleteList(List<T> entities);
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
