namespace SimpleSpecification.Specifications.Model
{
    public class Person : AbstractValidator<Person>
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public bool Approved { get; set; }

        public bool Suspended { get; set; }

        public override ISpecification<Person> Validator
        {
            get
            {
                return
                    Specification<Person>
                        .Where(p => p.Age >= 18)
                        .And(p => p.Approved)
                        .AndNot(p => p.Suspended);
            }
        }
    }
}
