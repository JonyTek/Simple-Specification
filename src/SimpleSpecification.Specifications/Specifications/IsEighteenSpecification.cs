using SimpleSpecification.Specifications.Model;

namespace SimpleSpecification.Specifications.Specifications
{
    public class IsEighteenSpecification : AbstractSpecification<Person>
    {
        public override bool IsSatisfiedBy(Person candidate)
        {
            return candidate.Age > 17;
        }
    }
}