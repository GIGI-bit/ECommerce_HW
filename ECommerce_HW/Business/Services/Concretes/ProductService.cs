using ECommerce_HW.Business.Services.Abstracts;
using ECommerce_HW.Core.Abstraction;
using ECommerce_HW.Core.Concretes;
using ECommerce_HW.DataAccess.Abstraction;
using ECommerce_HW.DataAccess.Concrete;
using ECommerce_HW.Entities;

namespace ECommerce_HW.Business.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task AddAsync(Product item)
        {
            await _productDal.Add(item);
        }

        public async Task DeleteAsync(Product item)
        {
            await _productDal.Delete(item);
        }

        public async Task<List<Product>> GetAllAsync()
        {
          return  await _productDal.GetList();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productDal.Get(p=>p.Id == id);
        }

        public async Task UpdateAsync(Product item)
        {
            await _productDal.Update(item);
        }
    }
}
