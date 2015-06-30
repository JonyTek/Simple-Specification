using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSpecification.Specifications.Model;
using SimpleSpecification.Specifications.Specifications;

namespace SimpleSpecification.UnitTests.Specifications
{
    [TestClass]
    public class IsEighteenSpec
    {
        [TestMethod]
        public void ShouldReturnTrueIfOver18()
        {
            var specification = new IsEighteenSpecification();

            var person = new Person { Age = 18 };

            Assert.IsTrue(specification.IsSatisfiedBy(person));
        }

        [TestMethod]
        public void ShouldReturnFalseIfAccountNotApproved()
        {
            var specification = new IsEighteenSpecification();

            var person = new Person { Age = 17 };

            Assert.IsFalse(specification.IsSatisfiedBy(person));
        }
    }
}