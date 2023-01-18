using AutoFixture;
using AutoFixture.Xunit2;
using Warehouse.Domain.Entities;

namespace Tests.Attributes
{
    public class AutoWorkerData : AutoDataAttribute
    {
        public AutoWorkerData() : base(FixtureFactory)
        {
        }

        private static IFixture FixtureFactory()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            fixture.Customize<Worker>(c => c.Without(u => u.WorkersDepartments));

            return fixture;
        }
    }
}
