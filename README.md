# Simple-Specification
A simple C# implementation of the Specification pattern

In computer programming, the specification pattern is a particular software design pattern, whereby business rules can be recombined by chaining the business rules together using boolean logic. The pattern is frequently used in the context of domain-driven design.

There are a number of different syntaxes that can be used. The easiest and cleanest implementation follows although implementations can be found within the unit test project.

### NuGet Packages

```
PM> Install-Package SimpleSpecification.dll
```

Usage
Define a model class

```csharp
//Basic Person model
public class Person
{
	public int Age { get; set; }

	public bool Approved { get; set; }
}
```

Either use expressions or define unit testable specification classes

```csharp
//Use expression syntax
var spec = Specification<Person>.Where(p => p.Age > 10).Or(p => p.Approved);

Assert.IsTrue(spec.IsSatisfiedBy(new Person {Age = 0, Approved = true}));

//Use new syntx
spec = Specification<Person>.Where(p => p.Age > 10).Or(new SomeSpecification());

Assert.IsTrue(spec.IsSatisfiedBy(new Person {Age = 0}));

//Use generic syntax
spec = Specification<Person>.Where(p => p.Age > 10).Or<SomeSpecification>();

Assert.IsTrue(spec.IsSatisfiedBy(new Person {Age = 0}));

//Specification class
public class SomeSpecification : AbstractSpecification<Person>
{
	public override bool IsSatisfiedBy(Person candidate)
	{
		//Insert logic here
	}
}
```

A model class can also contain validation logic similar to the pattern used within FluentValidation

```csharp
//AbstractValidator implementation
 public abstract class AbstractValidator<T>
        where T : AbstractValidator<T>
{
	public abstract ISpecification<T> Validator { get; }

	public bool IsValid
	{
		get { return Validator.IsSatisfiedBy(this as T); }
	}
}
```

```csharp
//Extent AbstractValidator<T>
public class Person : AbstractValidator<Person>
{
	public int Age { get; set; }

	public bool Approved { get; set; }
	
	//Implement validation logic
	public override ISpecification<Person> Validator
	{
		get { return Specification<Person>.Where(p => p.Age >= 18).And(p => p.Approved); }
	}
}
```

```csharp
var  person = new Person {Age = 18, Approved = true};

Assert.IsTrue(person.IsValid);
```

ISpecification interface
```csharp
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
```

Enjoy and let me know what you think..