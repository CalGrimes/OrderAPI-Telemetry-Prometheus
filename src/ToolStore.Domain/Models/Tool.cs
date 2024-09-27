using System.Runtime.Serialization;

namespace ToolStore.Domain.Models
{
    public class Tool : Entity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public Category Category { get; set; }
        public Inventory Inventory { get; set; }
        public List<Order> Orders { get; set; }

        public bool hasPositivePrice()
        {
            return Price > 0;
        }
    }


    

}
