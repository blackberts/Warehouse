using AutoMapper;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Models;

namespace Warehouse.Application.Mapping
{
    public class ProductModelMapping : Profile
    {
        public ProductModelMapping()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
