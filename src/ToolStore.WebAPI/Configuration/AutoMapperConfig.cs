using AutoMapper;
using ToolStore.Domain.Models;
using ToolStore.WebApi.Dtos.Book;
using ToolStore.WebApi.Dtos.Category;
using ToolStore.WebApi.Dtos.Inventory;
using ToolStore.WebApi.Dtos.Order;
using Microsoft.AspNetCore.Identity;
using System.Numerics;
using ToolStore.WebApi.Dtos.Tool;

namespace ToolStore.WebApi.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Category, CategoryResultDto>().ReverseMap();
            
            CreateMap<Tool, ToolAddDto>().ReverseMap();
            CreateMap<Tool, ToolEditDto>().ReverseMap();
            CreateMap<Tool, ToolResultDto>().ReverseMap();
            
            CreateMap<InventoryResultDto, Inventory>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.ToolId))
                .ForMember(x => x.Amount, opt => opt.MapFrom(m => m.Amount))
                .ForMember(x => x.Tool, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<InventoryEditDto, Inventory>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.ToolId))
                .ForMember(x => x.Amount, opt => opt.MapFrom(m => m.Amount))
                .ForMember(x => x.Tool, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<InventoryAddDto, Inventory>()
                .ForMember(x => x.Id, opt => opt.MapFrom(m => m.ToolId))
                .ForMember(x => x.Tool, opt => opt.Ignore())
                .ForMember(x => x.Amount, opt => opt.MapFrom(m => m.Amount))
                .ReverseMap();
            
            CreateMap<int, Tool>()
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src));
            CreateMap<OrderAddDto, Order>()
                .ForMember(x => x.Tools, opt => opt.MapFrom(m => m.Tools));

            CreateMap<Order, OrderResultDto>()
                .ForMember(x => x.Tools, opt => opt.MapFrom(m => m.Tools.Select(x => x.Id).ToList()));
        }
    }
}
