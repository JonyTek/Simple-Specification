using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSpecification.Specifications.Model;
using SimpleSpecification.Specifications.Specifications;
using SimpleSpecification.UnitTests.Specifications;

namespace SimpleSpecification.UnitTests
{
    [TestClass]
    public class OrNotSpecificationSpecs
    {
        [TestMethod]
        public void ShouldReturnTrue()
        {
            var spec = Specification<Person>.Where(p => p.Age > 10).OrNot(p => p.Approved);

            Assert.IsTrue(spec.IsSatisfiedBy(new Person {Age = 0, Approved = false}));

            spec = Specification<Person>.Where(p => p.Age > 10).OrNot(new FalseSpecification());

            Assert.IsTrue(spec.IsSatisfiedBy(new Person {Age = 0}));

            spec = Specification<Person>.Where(p => p.Age > 10).OrNot<FalseSpecification>();

            Assert.IsTrue(spec.IsSatisfiedBy(new Person {Age = 0}));
        }

        [TestMethod]
        public void ShouldReturnFalse()
        {
            var spec = Specification<Person>.Where(p => p.Age > 10).OrNot(p => p.Approved.Not());

            Assert.IsFalse(spec.IsSatisfiedBy(new Person {Age = 0, Approved = false}));

            spec = Specification<Person>.Where(p => p.Age > 10).OrNot(new TrueSpecification());

            Assert.IsFalse(spec.IsSatisfiedBy(new Person {Age = 0}));

            spec = Specification<Person>.Where(p => p.Age > 10).OrNot<TrueSpecification>();

            Assert.IsFalse(spec.IsSatisfiedBy(new Person {Age = 0}));
        }
    }
}