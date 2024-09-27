using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolStore.Domain.Interfaces;
using ToolStore.Domain.Models;
using ToolStore.Infrastructure.Context;
using ToolStore.Infrastructure.Metrics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ToolStore.Infrastructure.Repositories
{
    public class OrderRepository(ToolStoreDbContext context,
        ToolStoreMetrics meters) : Repository<Tool>(context), IOrderRepository
    {
        public Task Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByToolId(int toolId)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> Search(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRange(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        Task<List<Order>> IRepository<Order>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Order> IRepository<Order>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
