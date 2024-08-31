using ECommerce_HW.Core.Abstraction;

namespace ECommerce_HW.Entities
{
    public class Order:IEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
