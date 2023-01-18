using Warehouse.Domain.Entities;

namespace Tests.AutoData
{
    public static class WorkerData
    {
        public static List<Worker> CreateWorkersList()
        {
            var workerList = new List<Worker>()
            {
                new Worker()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Valera",
                    LastName = "2000",
                    FullName = "Valera 2000",
                },
                new Worker()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Artem",
                    LastName = "Ging",
                    FullName = "Artem Ging",
                },
                new Worker()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Abhas",
                    LastName = "Xart",
                    FullName = "Abhas Xart",
                },
                new Worker()
                {
                    Id = new Guid("0ab00674-97ea-45b1-b7f9-9c5f0b2568d5"),
                    FirstName = "Hasbula",
                    LastName = "Boec",
                    FullName = "Hasbula Boec",
                },
                new Worker()
                {
                    Id = new Guid("66bbc7ef-602a-47f7-a584-a226c8dc5d73"),
                    FirstName = "Arina",
                    LastName = "Xart",
                    FullName = "Arina Xart",
                },
                new Worker()
                {
                    Id = new Guid("7438754c-5a10-4012-a56f-4e76db7d7dac"),
                    FirstName = "Testik",
                    LastName = "Testovii",
                    FullName = "Testik Testovii",
                }
            };

            return workerList;
        }
    }
}
