using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolStore.Domain.Models;

namespace ToolStore.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<Order> Add(Order order);
        Task<Order> Remove(Order order);
    }
}