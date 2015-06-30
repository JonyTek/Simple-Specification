using SimpleSpecification.Specifications.Model;

namespace SimpleSpecification.Specifications.Specifications
{
    public class FalseSpecification : AbstractSpecification<Person>
    {
        public override bool IsSatisfiedBy(Person candidate)
        {
            return false;
        }
    }
}