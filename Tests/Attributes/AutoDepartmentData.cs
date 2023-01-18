using AutoFixture.Xunit2;
using AutoFixture;
using Warehouse.Domain.Entities;

namespace Tests.Attributes
{
    public class AutoDepartmentData : AutoDataAttribute
    {
        public AutoDepartmentData() : base(FixtureFactory)
        {
        }

        private static IFixture FixtureFactory()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            fixture.Customize<Department>(c => c.Without(u => u.WorkersDepartments)
            .Without(u => u.Products));

            return fixture;
        }
    }
}
