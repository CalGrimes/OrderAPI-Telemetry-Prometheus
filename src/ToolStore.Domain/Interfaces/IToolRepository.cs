using ToolStore.Domain.Models;
namespace ToolStore.Domain.Interfaces
{
    public interface IToolRepository : IRepository<Tool>
    {
        new Task<List<Tool>> GetAll();
        new Task<Tool> GetById(int id);
        Task<IEnumerable<Tool>> GetToolsByCategory(int categoryId);
        Task<IEnumerable<Tool>> SearchToolWithCategory(string searchedValue);
    }
}
