namespace SimpleSpecification
{
    public class NotSpecification<T> : AbstractSpecification<T>
    {
        private readonly ISpecification<T> _innerSpecification;

        public NotSpecification(ISpecification<T> innerSpecification)
        {
            _innerSpecification = innerSpecification;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return !_innerSpecification.IsSatisfiedBy(candidate);
        }
    }
}