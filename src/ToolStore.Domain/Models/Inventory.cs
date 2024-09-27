using ToolStore.Domain.Models;

namespace ToolStore.Domain.Models
{
    public class Inventory : Entity
    {
        public int Amount { get; set; }
        public virtual Tool Tool { get; set; }

        public bool HasInventoryAvailable()
        {
            return Amount > 0;
        }

        public void DecreaseInventory()
        {
            Amount -= 1;
        }

        public void IncreaseInventory()
        {
            Amount += 1;
        }
    }
}