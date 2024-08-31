using ECommerce_HW.Core.Concretes;
using ECommerce_HW.DataAccess.Abstraction;
using ECommerce_HW.Entities;

namespace ECommerce_HW.DataAccess.Concrete
{
    public class EFProductDal:EFEntityRepositoryBase<Product,ShopDbContext>,IProductDal
    {

        public EFProductDal(ShopDbContext context):base(context)
        {
            
        }
    }
}
