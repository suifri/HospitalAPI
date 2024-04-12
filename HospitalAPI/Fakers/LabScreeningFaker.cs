using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class LabScreeningFaker : Faker<LabScreening>
    {
        public LabScreeningFaker() 
        {
            RuleFor(l => l.Id, Guid.NewGuid());
            RuleFor(l => l.TestCost, f => f.Random.Decimal(10, 700));
            RuleFor(l => l.Date, f => f.Date.RecentDateOnly());
            //RuleFor(l => , f =>);
            //RuleFor(l => , f =>);
        }
    }
}
