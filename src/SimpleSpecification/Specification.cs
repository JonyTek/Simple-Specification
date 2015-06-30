using System;

namespace SimpleSpecification
{
    public class Specification<T> : AbstractSpecification<T>
    {
        private Func<T, bool> _expression;

        private Specification(){}

        public ISpecification<T> Where(ISpecification<T> spec)
        {
            return spec;
        }

        public static ISpecification<T> Where<TSpec>()
            where TSpec : ISpecification<T>, new()
        {
            return new TSpec();
        }

        public static ISpecification<T> Where(Func<T, bool> expression)
        {
            return new Specification<T> {_expression = expression};
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return _expression(candidate);
        }
    }
}