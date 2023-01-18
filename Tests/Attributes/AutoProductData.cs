using AutoFixture;
using AutoFixture.Xunit2;
using Warehouse.Domain.Entities;

namespace Tests.Attributes
{
    public class AutoProductData : AutoDataAttribute
    {
        public AutoProductData() : base(FixtureFactory)
        {
        }

        private static IFixture FixtureFactory()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            fixture.Customize<Product>(c => c.Without(u => u.Department)
            .Without(u => u.DeparmentId));

            return fixture;
        }
    }
}
