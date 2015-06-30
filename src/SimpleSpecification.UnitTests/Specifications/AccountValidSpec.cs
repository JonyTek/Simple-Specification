using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSpecification.Specifications.Model;
using SimpleSpecification.Specifications.Specifications;

namespace SimpleSpecification.UnitTests.Specifications
{
    [TestClass]
    public class AccountValidSpec
    {
        [TestMethod]
        public void ShouldReturnTrueIfAccountValid()
        {
            var specification = new ValidSpecification();

            var person = new Person { Approved = true, Suspended = false};

            Assert.IsTrue(specification.IsSatisfiedBy(person));
        }

        [TestMethod]
        public void ShouldReturnFalseIfAccountNotApproved()
        {
            var specification = new ValidSpecification();

            var person = new Person { Approved = false , Suspended = false};

            Assert.IsFalse(specification.IsSatisfiedBy(person));
        }

        [TestMethod]
        public void ShouldReturnFalseIfAccountSuspended()
        {
            var specification = new ValidSpecification();

            var person = new Person { Approved = true, Suspended = true};

            Assert.IsFalse(specification.IsSatisfiedBy(person));
        }
    }
}