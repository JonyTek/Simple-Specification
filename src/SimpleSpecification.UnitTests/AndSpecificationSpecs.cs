using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSpecification.Specifications.Model;
using SimpleSpecification.Specifications.Specifications;
using SimpleSpecification.UnitTests.Specifications;

namespace SimpleSpecification.UnitTests
{
    [TestClass]
    public class AndSpecificationSpecs
    {
        [TestMethod]
        public void ShouldReturnTrue()
        {
            var spec = Specification<Person>.Where(p => p.Age > 10).And(p => p.Approved);

            Assert.IsTrue(spec.IsSatisfiedBy(new Person { Age = 11, Approved = true }));

            spec = Specification<Person>.Where(p => p.Age > 10).And(new TrueSpecification());

            Assert.IsTrue(spec.IsSatisfiedBy(new Person { Age = 11 }));

            spec = Specification<Person>.Where(p => p.Age > 10).And<TrueSpecification>();

            Assert.IsTrue(spec.IsSatisfiedBy(new Person { Age = 11 }));
        }

        [TestMethod]
        public void ShouldReturnFalse()
        {
            var spec = Specification<Person>.Where(p => p.Age > 10).And(p => p.Approved.Not());

            Assert.IsFalse(spec.IsSatisfiedBy(new Person { Age = 11, Approved = true }));

            spec = Specification<Person>.Where(p => p.Age > 10).And(new FalseSpecification());

            Assert.IsFalse(spec.IsSatisfiedBy(new Person { Age = 11 }));

            spec = Specification<Person>.Where(p => p.Age > 10).And<FalseSpecification>();

            Assert.IsFalse(spec.IsSatisfiedBy(new Person { Age = 11 }));
        }
    }
}