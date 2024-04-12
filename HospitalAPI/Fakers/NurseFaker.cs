using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class NurseFaker : Faker<Nurse>
    {
        public NurseFaker() 
        {
            RuleFor(n => n.Id, Guid.NewGuid());
            /*RuleFor(n => , f => );
            RuleFor(n => , f => );
            RuleFor(n => , f => );*/
        }
    }
}
