using ECommerce_HW.Core.Concretes;
using ECommerce_HW.DataAccess.Abstraction;
using ECommerce_HW.Entities;

namespace ECommerce_HW.DataAccess.Concrete
{
    public class EFCustomerDal:EFEntityRepositoryBase<Customer,ShopDbContext>,ICustomerDal
    {
        public EFCustomerDal(ShopDbContext context):base(context)
        {
            
        }
    }
}
