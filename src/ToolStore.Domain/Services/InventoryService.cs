using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolStore.Domain.Interfaces;
using ToolStore.Domain.Models;

namespace toolStore.Domain.Services
{
    public class InventoryService(IInventoryRepository inventoryRepository,
            IToolRepository toolRepository,
            IOrderRepository orderRepository)
        : IInventoryService
    {
        public async Task<Inventory> GetById(int id)
        {
            return await inventoryRepository.GetById(id);
        }

        public async Task<Inventory> Add(Inventory inventory)
        {
            if (inventoryRepository.Search(b => b.Id == inventory.Id).Result.Any())
                return null;

            if (await toolRepository.GetById(inventory.Id) is null)
                return null;

            await inventoryRepository.Add(inventory);
            return inventory;
        }

        public async Task<Inventory> Update(Inventory inventory)
        {
            if (inventoryRepository.Search(b => b.Id != inventory.Id).Result.Any())
                return null;

            await inventoryRepository.Update(inventory);
            return inventory;
        }

        public async Task<bool> Remove(Inventory inventory)
        {
            var orders = await orderRepository.GetOrdersByToolId(inventory.Id);

            if (orders.Any(x => !x.IsAlreadyCancelled()))
                return false;

            await inventoryRepository.Remove(inventory);
            return true;
        }

        public Task<IEnumerable<Inventory>> SearchInventoryForTool(string searchedValue)
        {
            throw new NotImplementedException();
        }
    }
}