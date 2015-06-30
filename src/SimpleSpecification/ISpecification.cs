using System;

namespace SimpleSpecification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);

        //AND
        ISpecification<T> And(ISpecification<T> other);

        ISpecification<T> And<TSpec>() where TSpec : ISpecification<T>, new();

        ISpecification<T> And(Func<T, bool> expression);

        
        //AND NOT
        ISpecification<T> AndNot(ISpecification<T> other);
        
        ISpecification<T> AndNot<TSpec>() where TSpec : ISpecification<T>, new();

        ISpecification<T> AndNot(Func<T, bool> expression);

        
        //NOT
        ISpecification<T> Not();


        //OR
        ISpecification<T> Or(ISpecification<T> other);

        ISpecification<T> Or<TSpec>() where TSpec : ISpecification<T>, new();

        ISpecification<T> Or(Func<T, bool> expression);


        //OR NOT
        ISpecification<T> OrNot(ISpecification<T> other);

        ISpecification<T> OrNot<TSpec>() where TSpec : ISpecification<T>, new();

        ISpecification<T> OrNot(Func<T, bool> expression);
    }
}