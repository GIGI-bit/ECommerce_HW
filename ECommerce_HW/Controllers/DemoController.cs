using ECommerce_HW.Business.Services.Abstracts;
using ECommerce_HW.Core.Abstraction;
using ECommerce_HW.DTOs;
using ECommerce_HW.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce_HW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public DemoController(IProductService productService, ICustomerService customerService, IOrderService orderService)
        {
            _productService = productService;
            _customerService = customerService;
            _orderService = orderService;
        }

        [HttpGet("GetProductsAsync")]
        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var collection = await _productService.GetAllAsync();
            var dtos = collection.Select(p => new ProductDTO
            {
                Name = p.Name,
                Price = p.Price,
                Discount = p.Discount
            });
            return dtos;

        }

        [HttpGet("GetCustomersAsync")]
        public async Task<IEnumerable<CustomerDTO>> GetCustomersAsync()
        {
            var collection = await _customerService.GetAllAsync();
            var dtos = collection.Select(c => new CustomerDTO
            {
                Name = c.Name,
                Surname = c.Surname
            });
            return dtos;
        }

        [HttpGet("GetOrderAsync")]
        public async Task<IEnumerable<OrderDTO>> GetOrderAsync()
        {
            var collection = await _orderService.GetAllAsync();
            var products = await _productService.GetAllAsync();
            var customers = await _customerService.GetAllAsync();

            var dtos = collection.Select(o => new OrderDTO
            {
                OrderDate = DateTime.Now,
                CustomerName = customers.FirstOrDefault(c => c.Id == o.CustomerId)!.Name,
                ProductName = products.FirstOrDefault(p => p.Id == o.ProductId)!.Name
            });
            return dtos;
        }

        // GET api/<DemoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetById(id);
            if (product != null)
            {
                var dto = new ProductDTO
                {
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount,
                };
                return Ok(dto);
            }
            return NotFound();

        }

        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var product = await _customerService.GetById(id);
            if (product != null)
            {
                var dto = new CustomerDTO
                {
                    Name = product.Name,
                    Surname = product.Surname,
                };
                return Ok(dto);
            }
            return NotFound();

        }

        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetById(id);
            var product = await _productService.GetAllAsync();
            var customer = await _customerService.GetAllAsync();

            if (order != null)
            {
                var dto = new OrderDTO
                {
                    OrderDate = order.OrderDate,
                    CustomerName = customer.FirstOrDefault(c => c.Id == order.CustomerId)!.Name,
                    ProductName = product.FirstOrDefault(p => p.Id == order.ProductId)!.Name,
                };
                return Ok(dto);
            }
            return NotFound();

        }



        // POST api/<DemoController>
        [HttpPost("PostProduct")]
        public async Task<IActionResult> PostProduct([FromBody] ProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Discount = dto.Discount,
                Id = (new Random()).Next(10, 1000),
            };

            await _productService.AddAsync(product);
            return Ok(product);

        }


        [HttpPost("PostCustomer")]
        public async Task<IActionResult> PostCustomer([FromBody] CustomerDTO dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Surname= dto.Surname,
                Id = (new Random()).Next(10, 1000),
            };

            await _customerService.AddAsync(customer);
            return Ok(customer);

        }

        [HttpPost("PostOrder")]
        public async Task<IActionResult> PostOrder([FromBody] ExtendedOrderDTO dto)
        {
            var order = new Order
            {
                ProductId=dto.ProductId,
                CustomerId=dto.CustomerId,
                OrderDate=dto.OrderDate,
                Id = (new Random()).Next(10, 1000),
            };

            await _orderService.AddAsync(order);
            return Ok(order);

        }

        // PUT api/<DemoController>/5
        [HttpPut("PutProduct/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDTO dto)
        {
            var productList =await _productService.GetAllAsync();
            var product =productList.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                product.Name= dto.Name;
                product.Price = dto.Price;
                product.Discount = dto.Discount;
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPut("PutOrder/{id}")]
        public async Task<IActionResult> PutOrder(int id, [FromBody] ExtendedOrderDTO dto)
        {
            var orderList = await _orderService.GetAllAsync();
            var order= orderList.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                order.OrderDate= dto.OrderDate;
                order.ProductId= dto.ProductId;
                order.CustomerId = dto.CustomerId;
                
                return Ok(order);
            }
            return NotFound();
        }

        [HttpPut("PutCustomer/{id}")]
        public async Task<IActionResult> PutCustomer(int id, [FromBody] CustomerDTO dto)
        {
            var customerList = await _customerService.GetAllAsync();
            var customer= customerList.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                customer.Name= dto.Name;
                customer.Surname = dto.Surname;


                return Ok(customer);
            }
            return NotFound();
        }

        // DELETE api/<DemoController>/5
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var prodList = await _productService.GetAllAsync();
            var orderList = await _orderService.GetAllAsync();
            var product = prodList.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {

                var selectedOrders = orderList.Where(o => o.ProductId == product.Id).ToList();
                await _orderService.DeleteList(selectedOrders);
                await _productService.DeleteAsync(product);
                return NoContent();
            }
            return NotFound();

        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customerList = await _customerService.GetAllAsync();
            var orderList = await _orderService.GetAllAsync();
            var customer = customerList.FirstOrDefault(p => p.Id == id);
            if (customer != null)
            {
                var selectedOrders = orderList.Where(o => o.CustomerId == customer.Id).ToList();
                await _orderService.DeleteList(selectedOrders);
                await _customerService.DeleteAsync(customer);
                return NoContent();
            }
            return NotFound();

        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            await _orderService.DeleteAsync(order);
            return NoContent();

        }

    }
}
