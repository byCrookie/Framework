using AutoFixture;

namespace Framework.Extensions.Fixture;

public static class FixtureExtensions
{
    public static AutoFixture.Fixture IgnoreCircular(this AutoFixture.Fixture fixture)
    {
        fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        return fixture;
    }
        
    public static AutoFixture.Fixture OnlyOwnValues(this AutoFixture.Fixture fixture)
    {
        fixture.Customizations.Add(new OmitSpecimenBuilder());
        return fixture;
    }
}