using ECommerce_HW.Core.Abstraction;

namespace ECommerce_HW.Entities
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
