using ECommerce_HW.Entities;

namespace ECommerce_HW.DTOs
{
    public class ExtendedOrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        
    }
}
