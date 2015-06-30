using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSpecification.Specifications.Model;

namespace SimpleSpecification.UnitTests
{
    [TestClass]
    public class ChainSpecificationSpecs
    {
        [TestMethod]
        public void ShouldAllowSpecsToBeChained()
        {
            var spec = Specification<Person>
                .Where(p => p.Age == 10)
                .AndNot(p => p.Approved)
                .AndNot(p => p.Suspended);

            Assert.IsTrue(spec.IsSatisfiedBy(new Person { Age = 10 }));
        }
        
        [TestMethod]
        public void ShouldAllowSpecsToBeChained1()
        {
            var spec = Specification<Person>.Where(p => p.Age == 10).Or(p => p.Age == 21);
            
            Assert.IsTrue(spec.IsSatisfiedBy(new Person { Age = 10 }));

            spec = spec.AndNot(p => p.Age == 10);

            Assert.IsFalse(spec.IsSatisfiedBy(new Person { Age = 10 }));
        }

        [TestMethod]
        public void ShouldAllowSpecsToBeChained2()
        {
            var spec = Specification<Person>.Where(p => p.Age == 10)
                .Or(p => p.Approved && p.Suspended.Not());

            Assert.IsTrue(spec.IsSatisfiedBy(new Person { Age = 10 }));

            spec = spec.AndNot(p => p.Age == 10);

            Assert.IsFalse(spec.IsSatisfiedBy(new Person { Age = 10 }));
        }
    }
}