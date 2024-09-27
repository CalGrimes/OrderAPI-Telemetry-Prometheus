using ToolStore.Domain.Models;

namespace ToolStore.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetOrdersByToolId(int toolId);
    }
}
