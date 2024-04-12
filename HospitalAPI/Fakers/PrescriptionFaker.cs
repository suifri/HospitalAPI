using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class PrescriptionFaker : Faker<Prescription>
    {
        public PrescriptionFaker()
        {
            RuleFor(p => p.Id, Guid.NewGuid());
            RuleFor(p => p.Date, f => f.Date.Past());
            RuleFor(p => p.Dosage, f => f.Random.Number(1, 12));
            //RuleFor(p => , f =>);
            //RuleFor(p => , f =>);
            //RuleFor(p => , f =>);
        }
    }
}
