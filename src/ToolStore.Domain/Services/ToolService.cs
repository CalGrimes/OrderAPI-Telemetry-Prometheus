using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolStore.Domain.Interfaces;
using ToolStore.Domain.Models;

namespace ToolStore.Domain.Services
{
    public class ToolService : IToolService
    {
        public Task<Tool> Add(Tool tool)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tool>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tool> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tool>> GetToolsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Tool tool)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tool>> Search(string toolName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tool>> SearchToolWithCategory(string searchedValue)
        {
            throw new NotImplementedException();
        }

        public Task<Tool> Update(Tool tool)
        {
            throw new NotImplementedException();
        }
    }
}
