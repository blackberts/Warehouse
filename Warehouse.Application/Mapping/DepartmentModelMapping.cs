using AutoMapper;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Models;

namespace Warehouse.Application.Mapping
{
    public class DepartmentModelMapping : Profile
    {
        public DepartmentModelMapping()
        {
            CreateMap<DepartmentModel, Department>().ReverseMap();
        }
    }
}
