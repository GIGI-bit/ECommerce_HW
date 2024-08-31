using ECommerce_HW.Business.Services.Abstracts;
using ECommerce_HW.DataAccess.Abstraction;
using ECommerce_HW.DataAccess.Concrete;
using ECommerce_HW.Entities;

namespace ECommerce_HW.Business.Services.Concretes
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerDal _customerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task AddAsync(Customer item)
        {
            await _customerDal.Add(item);
        }

        public async Task DeleteAsync(Customer item)
        {
            await _customerDal.Delete(item);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerDal.GetList();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _customerDal.Get(p => p.Id == id);
        }

        public async Task UpdateAsync(Customer item)
        {
            await _customerDal.Update(item);
        }
    }
}
