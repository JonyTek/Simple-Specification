using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSpecification.Specifications.Model;
using SimpleSpecification.Specifications.Specifications;
using SimpleSpecification.UnitTests.Specifications;

namespace SimpleSpecification.UnitTests
{
    [TestClass]
    public class Usages
    {
        private Person _person;

        [TestInitialize]
        public void OnBeforeEachTest()
        {
            _person = new Person
            {
                Age = 18,
                Approved = true,
                Suspended = false
            };
        }

        [TestMethod]
        public void Implementation1()
        {
            var accountApproved = new ValidSpecification();
            var isOverEighteen = new IsEighteenSpecification();
            var spec = accountApproved.And(isOverEighteen);

            Assert.IsTrue(spec.IsSatisfiedBy(_person));

            _person.Age = 17;

            Assert.IsFalse(spec.IsSatisfiedBy(_person));
        }

        [TestMethod]
        public void Implementation2()
        {
            var accountApproved = new ValidSpecification();
            var spec = accountApproved.And<IsEighteenSpecification>();

            Assert.IsTrue(spec.IsSatisfiedBy(_person));

            _person.Approved = false;

            Assert.IsFalse(spec.IsSatisfiedBy(_person));
        }

        [TestMethod]
        public void Implementation3()
        {
            var newSyntax = Specification<Person>
                .Where<TrueSpecification>()
                .AndNot<FalseSpecification>();
            
            Assert.IsTrue(newSyntax.IsSatisfiedBy(new Person()));

            var spec = Specification<Person>
                .Where(p => p.Age >= 18)
                .And<ValidSpecification>();

            Assert.IsTrue(spec.IsSatisfiedBy(_person));

            _person.Suspended = true;

            Assert.IsFalse(spec.IsSatisfiedBy(_person));
        }

        [TestMethod]
        public void Implementation4()
        {
            var spec =
                Specification<Person>.Where(p => p.Age >= 18)
                    .And(p => p.Approved)
                    .And(p => p.Suspended.Not());

            Assert.IsTrue(spec.IsSatisfiedBy(_person));
        }

        [TestMethod]
        public void Implementation5()
        {
            var spec = Specification<Person>
                .Where(IsOverEighteen)
                .And(IsAccountApproved)
                .AndNot(IsAccountSuspended);

            Assert.IsTrue(spec.IsSatisfiedBy(_person));
        }

        [TestMethod]
        public void Implementation6()
        {
            Assert.IsTrue(_person.IsValid);

            _person.Age = 9;

            Assert.IsFalse(_person.IsValid);
        }

        private static bool IsOverEighteen(Person person)
        {
            return person.Age >= 18;
        }

        private static bool IsAccountApproved(Person person)
        {
            return person.Approved;
        }

        private static bool IsAccountSuspended(Person person)
        {
            return person.Suspended;
        }
    }
}
