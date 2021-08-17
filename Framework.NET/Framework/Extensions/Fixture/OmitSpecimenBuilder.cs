using AutoFixture.Kernel;

namespace Framework.Extensions.Fixture
{
    public class OmitSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            return new OmitSpecimen();
        }
    }
}