using SimpleSpecification.Specifications.Model;

namespace SimpleSpecification.Specifications.Specifications
{
    public class TrueSpecification : AbstractSpecification<Person>
    {
        public override bool IsSatisfiedBy(Person candidate)
        {
            return true;
        }
    }
}