using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolStore.Domain.Interfaces;
using ToolStore.Domain.Models;
using ToolStore.Infrastructure.Context;
using ToolStore.Infrastructure.Metrics;
using ToolStore.Infrastructure.Repositories;

namespace toolStore.Infrastructure.Repositories
{
    public class toolRepository(ToolStoreDbContext context,
        ToolStoreMetrics meters) : Repository<Tool>(context), IToolRepository
    {
        public override async Task<List<Tool>> GetAll()
        {
            return await Db.Tools.Include(b => b.Category)
                .OrderBy(b => b.Name)
                .ToListAsync();
        }

        public override async Task<Tool> GetById(int id)
        {
            return await Db.Tools.Include(b => b.Category)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tool>> GetToolsByCategory(int categoryId)
        {
            return await Search(b => b.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Tool>> SearchToolWithCategory(string searchedValue)
        {
            return await Db.Tools.AsNoTracking()
                .Include(b => b.Category)
                .Where(b => b.Name.Contains(searchedValue) ||
                            b.Description.Contains(searchedValue) ||
                            b.Category.Name.Contains(searchedValue))
                .ToListAsync();
        }

        public override async Task Add(Tool entity)
        {
            await base.Add(entity);

            meters.AddTool();
            meters.IncreaseTotalTools();
        }

        public override async Task Update(Tool entity)
        {
            await base.Update(entity);

            meters.UpdateTool();
        }

        public override async Task Remove(Tool entity)
        {
            await base.Remove(entity);

            meters.DeleteTool();
            meters.DecreaseTotalTools();
        }
    }
}