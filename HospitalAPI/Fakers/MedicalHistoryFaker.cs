using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class MedicalHistoryFaker : Faker<MedicalHistory>
    {
        public MedicalHistoryFaker() 
        {
            RuleFor(m => m.Id, Guid.NewGuid() );
            RuleFor(m => m.Allergies, f => f.Lorem.Word()); // add allergies
            RuleFor(m => m.PreConditions, f => f.Lorem.Word());
            //RuleFor(m => m., f => );
        }
    }
}
