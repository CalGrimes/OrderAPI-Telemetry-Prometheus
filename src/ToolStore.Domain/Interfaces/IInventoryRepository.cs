using System.Collections.Generic;
using System.Threading.Tasks;
using ToolStore.Domain.Models;

namespace ToolStore.Domain.Interfaces
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<IEnumerable<Inventory>> SearchInventoryForTool(string toolName);
    }
}