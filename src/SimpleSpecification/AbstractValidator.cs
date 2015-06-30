namespace SimpleSpecification
{
    public abstract class AbstractValidator<T>
        where T : AbstractValidator<T>
    {
        public abstract ISpecification<T> Validator { get; }

        public bool IsValid
        {
            get { return Validator.IsSatisfiedBy(this as T); }
        }
    }
}
