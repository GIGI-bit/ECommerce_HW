using ECommerce_HW.Business.Services.Abstracts;
using ECommerce_HW.DataAccess.Abstraction;
using ECommerce_HW.DataAccess.Concrete;
using ECommerce_HW.Entities;

namespace ECommerce_HW.Business.Services.Concretes
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderService(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task AddAsync(Order item)
        {
            await _orderDal.Add(item);
        }

        public async Task DeleteAsync(Order item)
        {
            await _orderDal.Delete(item);
        }

        public async Task DeleteList(List<Order> orders)
        {
            await _orderDal.DeleteList(orders);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderDal.GetList();
        }

        public async Task<Order> GetById(int id)
        {
            return await _orderDal.Get(p => p.Id == id);
        }

       

        public async Task UpdateAsync(Order item)
        {
            await _orderDal.Update(item);
        }
    }
}
