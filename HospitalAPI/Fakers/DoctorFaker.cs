using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class DoctorFaker : Faker<Doctor>
    {
        public DoctorFaker() 
        {
            RuleFor(d => d.Id, Guid.NewGuid());
            RuleFor(d => d.Qualifications, f => f.Lorem.Word());
            RuleFor(d => d.Specialization, f => f.Lorem.Word());
            //RuleFor(d => , f =>);
        }
    }
}
