using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSpecification.Specifications.Model;
using SimpleSpecification.Specifications.Specifications;
using SimpleSpecification.UnitTests.Specifications;

namespace SimpleSpecification.UnitTests
{
    [TestClass]
    public class AndNotSpecificationSpecs
    {
        [TestMethod]
        public void ShouldReturnTrue()
        {
            var spec = Specification<Person>.Where(p => p.Age > 10).AndNot(p => p.Approved);

            Assert.IsTrue(spec.IsSatisfiedBy(new Person {Age = 11, Approved = false}));

            spec = Specification<Person>.Where(p => p.Age > 10).AndNot(new FalseSpecification());

            Assert.IsTrue(spec.IsSatisfiedBy(new Person { Age = 11 }));

            spec = Specification<Person>.Where(p => p.Age > 10).AndNot<FalseSpecification>();

            Assert.IsTrue(spec.IsSatisfiedBy(new Person { Age = 11 }));
        }

        [TestMethod]
        public void ShouldReturnFalse()
        {
            var spec = Specification<Person>.Where(p => p.Age > 10).AndNot(p => p.Approved);

            Assert.IsFalse(spec.IsSatisfiedBy(new Person {Age = 11, Approved = true}));

            spec = Specification<Person>.Where(p => p.Age > 10).AndNot(new TrueSpecification());

            Assert.IsFalse(spec.IsSatisfiedBy(new Person { Age = 11 }));

            spec = Specification<Person>.Where(p => p.Age > 10).AndNot<TrueSpecification>();

            Assert.IsFalse(spec.IsSatisfiedBy(new Person { Age = 11 }));
        }
    }
}