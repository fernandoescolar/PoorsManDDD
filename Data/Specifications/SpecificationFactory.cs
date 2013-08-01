using PoorsManDDD.CrossDomain;
using PoorsManDDD.Domain.Specifications;

namespace PoorsManDDD.Data.Specifications
{
    internal class SpecificationFactory : ISpecificationFactory
    {
        private readonly IContainer container;

        public SpecificationFactory(IContainer container)
        {
            this.container = container;
        }

        public ISpecification GetSpecification(SpecificationType specificationType)
        {
            return this.container.Get<ISpecification>(specificationType.ToString());
        }
    }
}
