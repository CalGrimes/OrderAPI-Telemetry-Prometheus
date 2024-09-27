using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolStore.Domain.Interfaces;
using ToolStore.Domain.Models;
using ToolStore.Infrastructure.Context;
using ToolStore.Infrastructure.Repositories;

namespace ToolStore.Infrastructure.Repositories
{
    public class InventoryRepository(ToolStoreDbContext db) : Repository<Inventory>(db), IInventoryRepository
    {

        public async Task<IEnumerable<Inventory>> SearchInventoryForTool(string toolName)
        {
            return await Db.Inventories.AsNoTracking()
                .Include(b => b.Tool)
                .Where(b => b.Tool.Name.Contains(toolName))
                .ToListAsync();
        }
    }
}