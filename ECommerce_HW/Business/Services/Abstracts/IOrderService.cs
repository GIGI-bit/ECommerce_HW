using ECommerce_HW.Entities;

namespace ECommerce_HW.Business.Services.Abstracts
{
    public interface IOrderService:IBaseService<Order>
    {
        public Task DeleteList(List<Order> orders);


    }
}
