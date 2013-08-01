namespace PoorsManDDD.Domain.Specifications
{
    public interface ISpecificationFactory
    {
        ISpecification GetSpecification(SpecificationType specificationType);
    }
}
