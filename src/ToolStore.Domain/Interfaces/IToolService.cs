using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolStore.Domain.Models;

namespace ToolStore.Domain.Interfaces
{
    public interface IToolService
    {
        Task<IEnumerable<Tool>> GetAll();
        Task<Tool> GetById(int id);
        Task<Tool> Add(Tool tool);
        Task<Tool> Update(Tool tool);
        Task<bool> Remove(Tool tool);
        Task<IEnumerable<Tool>> GetToolsByCategory(int categoryId);
        Task<IEnumerable<Tool>> Search(string toolName);
        Task<IEnumerable<Tool>> SearchToolWithCategory(string searchedValue);
    }
}