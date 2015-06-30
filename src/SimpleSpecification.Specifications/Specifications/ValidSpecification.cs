using SimpleSpecification.Specifications.Model;

namespace SimpleSpecification.Specifications.Specifications
{
    public class ValidSpecification : AbstractSpecification<Person>
    {
        public override bool IsSatisfiedBy(Person candidate)
        {
            return candidate.Approved && !candidate.Suspended;
        }
    }
}