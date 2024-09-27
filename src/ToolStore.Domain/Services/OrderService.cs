using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolStore.Domain.Interfaces;
using ToolStore.Domain.Models;

namespace ToolStore.Domain.Services
{
    public class OrderService : IOrderService
    {
        public Task<Order> Add(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Remove(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
