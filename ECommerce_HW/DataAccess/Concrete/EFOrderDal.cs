using ECommerce_HW.Core.Concretes;
using ECommerce_HW.DataAccess.Abstraction;
using ECommerce_HW.Entities;

namespace ECommerce_HW.DataAccess.Concrete
{
    public class EFOrderDal:EFEntityRepositoryBase<Order,ShopDbContext>,IOrderDal
    {
        public EFOrderDal(ShopDbContext context):base(context)
        {
            
        }
    }
}
