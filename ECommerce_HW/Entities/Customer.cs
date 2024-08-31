using ECommerce_HW.Core.Abstraction;

namespace ECommerce_HW.Entities
{
    public class Customer:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
