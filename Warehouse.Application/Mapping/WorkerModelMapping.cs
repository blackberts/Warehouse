using AutoMapper;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Models;

namespace Warehouse.Application.Mapping
{
    public class WorkerModelMapping : Profile
    {
        public WorkerModelMapping()
        {
            CreateMap<Worker, WorkerModel>().ReverseMap();
        }
    }
}
