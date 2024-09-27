using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolStore.Domain.Interfaces;
using ToolStore.Domain.Models;

namespace toolStore.Domain.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IToolRepository toolRepository)
        : ICategoryService
    {
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await categoryRepository.GetById(id);
        }

        public async Task<Category> Add(Category category)
        {
            if (categoryRepository.Search(c => c.Name == category.Name).Result.Any())
                return null;

            await categoryRepository.Add(category);
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            if (categoryRepository.Search(c => c.Name == category.Name && c.Id != category.Id).Result.Any())
                return null;

            if (!categoryRepository.Search(c => c.Id == category.Id).Result.Any())
                return null;

            await categoryRepository.Update(category);
            return category;
        }

        public async Task<bool> Remove(Category category)
        {
            var tools = await toolRepository.GetToolsByCategory(category.Id);
            if (tools.Any()) return false;

            await categoryRepository.Remove(category);
            return true;
        }

        public async Task<IEnumerable<Category>> Search(string categoryName)
        {
            return await categoryRepository.Search(c => c.Name.Contains(categoryName));
        }
    }
}