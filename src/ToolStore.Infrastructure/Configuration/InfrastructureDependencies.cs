using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToolStore.Domain.Interfaces;
using ToolStore.Domain.Services;
using ToolStore.Infrastructure.Context;
using ToolStore.Infrastructure.Metrics;
using ToolStore.Infrastructure.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection RegisterInfrastureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToolStoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ToolStoreDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IToolRepository, ToolRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IToolService, ToolService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddSingleton<ToolStoreMetrics>();

            return services;
        }
    }
}