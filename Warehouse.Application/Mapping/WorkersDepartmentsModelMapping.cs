using AutoMapper;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Models;

namespace Warehouse.Application.Mapping
{
    public class WorkersDepartmentsModelMapping : Profile
    {
        public WorkersDepartmentsModelMapping()
        {
            CreateMap<WorkersDepartments, WorkersDepartmentsModel>().ReverseMap();
        }
    }
}
