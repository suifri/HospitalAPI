using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class InsuranceFaker : Faker<Insurance>
    {
        public InsuranceFaker() 
        {
            RuleFor(i => i.PolicyNumber, f => f.Random.AlphaNumeric(10));
            RuleFor(i => i.InsCode, f => f.Random.AlphaNumeric(8));
            RuleFor(i => i.EndDate, f => f.Date.Future().ToString("yyyy-MM-dd"));
            RuleFor(i => i.Provider, f => f.Company.CompanyName());
            RuleFor(i => i.Plan, f => f.Random.Word());
            RuleFor(i => i.Co_Pay, f => f.Random.Decimal(10, 100));
            RuleFor(i => i.Coverage, f => f.Random.Word());
            RuleFor(i => i.Maternity, f => f.Random.Bool());
            RuleFor(i => i.Dental, f => f.Random.Bool());
            RuleFor(i => i.Optical, f => f.Random.Bool());
            //RuleFor(i =>, f =>);
        }
    }
}
