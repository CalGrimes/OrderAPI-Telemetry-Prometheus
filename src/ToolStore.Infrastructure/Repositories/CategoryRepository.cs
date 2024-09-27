using ToolStore.Infrastructure.Metrics;
using ToolStore.Domain.Interfaces;
using ToolStore.Domain.Models;
using ToolStore.Infrastructure.Context;
 
namespace ToolStore.Infrastructure.Repositories
{
    public class CategoryRepository(ToolStoreDbContext context,
        ToolStoreMetrics meters) : Repository<Category>(context), ICategoryRepository
    {
        public override async Task Add(Category entity)
        {
            await base.Add(entity);
            meters.AddCategory();
            meters.IncreaseTotalCategories();
        }

        public override async Task Update(Category entity)
        {
            await base.Update(entity);
            meters.UpdateCategory();
        }

        public override async Task Remove(Category entity)
        {
            await base.Remove(entity);
            meters.DeleteCategory();
            meters.DecreaseTotalCategories();
        }


    }
}