using Warehouse.Domain.Entities;

namespace Tests.AutoData
{
    public static class DepartmentData
    {
        public static List<Department> CreateDepartmentsList()
        {
            var departmentList = new List<Department>()
            {
                new Department()
                {
                    Id = Guid.NewGuid(),
                    Name = "Food"
                },
                new Department()
                {
                    Id = Guid.NewGuid(),
                    Name = "Other"
                },
                new Department()
                {
                    Id = Guid.NewGuid(),
                    Name = "Idk"
                },
                new Department()
                {
                    Id = new Guid("36ad6d8c-cd06-4cda-88f5-d1957b3772a4"),
                    Name = "Test"
                },
                new Department()
                {
                    Id = new Guid("93eb5b3d-211e-4dd3-8503-01164ea65a66"),
                    Name = "Features"
                },
                new Department()
                {
                    Id = new Guid("9bf6b511-a0a5-4e47-ac0c-7ffa208f3d3b"),
                    Name = "Tech"
                },
            };

            return departmentList;
        }
    }
}
