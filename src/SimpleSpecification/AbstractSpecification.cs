using System;

namespace SimpleSpecification
{
    public abstract class AbstractSpecification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T candidate);

        //AND 
        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public ISpecification<T> And<TSpec>()
            where TSpec : ISpecification<T>, new()
        {
            return And(new TSpec());
        }

        public ISpecification<T> And(Func<T, bool> expression)
        {
            return And(Specification<T>.Where(expression));
        }

        //AND NOT
        public ISpecification<T> AndNot(ISpecification<T> other)
        {
            return And(other.Not());
        }
        
        public ISpecification<T> AndNot<TSpec>()
            where TSpec : ISpecification<T>, new()
        {
            return And(new TSpec().Not());
        }

        public ISpecification<T> AndNot(Func<T, bool> expression)
        {
            return And(Specification<T>.Where(expression).Not());
        }

        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        //OR
        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        public ISpecification<T> Or<TSpec>()
            where TSpec : ISpecification<T>, new()
        {
            return Or(new TSpec());
        }

        public ISpecification<T> Or(Func<T, bool> expression)
        {
            return Or(Specification<T>.Where(expression));
        }

        //OR NOT
        public ISpecification<T> OrNot<TSpec>()
            where TSpec : ISpecification<T>, new()
        {
            return Or(new TSpec().Not());
        }

        public ISpecification<T> OrNot(ISpecification<T> other)
        {
            return Or(other.Not());
        }

        public ISpecification<T> OrNot(Func<T, bool> expression)
        {
            return Or(Specification<T>.Where(expression).Not());
        }
    }
}