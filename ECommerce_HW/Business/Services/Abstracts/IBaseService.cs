using ECommerce_HW.Core.Abstraction;
using ECommerce_HW.Entities;

namespace ECommerce_HW.Business.Services.Abstracts
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
