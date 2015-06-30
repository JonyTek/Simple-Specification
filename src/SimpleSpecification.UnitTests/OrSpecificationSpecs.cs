using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSpecification.Specifications.Model;
using SimpleSpecification.Specifications.Specifications;
using SimpleSpecification.UnitTests.Specifications;

namespace SimpleSpecification.UnitTests
{
    [TestClass]
    public class OrSpecificationSpecs
    {
        [TestMethod]
        public void ShouldReturnTrue()
        {
            var spec = Specification<Person>.Where(p => p.Age > 10).Or(p => p.Approved);

            Assert.IsTrue(spec.IsSatisfiedBy(new Person {Age = 0, Approved = true}));

            spec = Specification<Person>.Where(p => p.Age > 10).Or(new TrueSpecification());

            Assert.IsTrue(spec.IsSatisfiedBy(new Person {Age = 0}));

            spec = Specification<Person>.Where(p => p.Age > 10).Or<TrueSpecification>();

            Assert.IsTrue(spec.IsSatisfiedBy(new Person {Age = 0}));
        }

        [TestMethod]
        public void ShouldReturnFalse()
        {
            var spec = Specification<Person>.Where(p => p.Age > 10).Or(p => p.Approved.Not());

            Assert.IsFalse(spec.IsSatisfiedBy(new Person {Age = 0, Approved = true}));

            spec = Specification<Person>.Where(p => p.Age > 10).Or(new FalseSpecification());

            Assert.IsFalse(spec.IsSatisfiedBy(new Person {Age = 0}));

            spec = Specification<Person>.Where(p => p.Age > 10).Or<FalseSpecification>();

            Assert.IsFalse(spec.IsSatisfiedBy(new Person {Age = 0}));
        }
    }
}