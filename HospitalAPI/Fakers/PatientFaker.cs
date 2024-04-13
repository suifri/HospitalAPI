using Bogus;
using HospitalAPI.Constants;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class PatientFaker : Faker<Patient>
    {
        private string[] Conditions = new string[] { PatientConditions.Stable, PatientConditions.Improving, PatientConditions.Deteriorating,
            PatientConditions.Rehabilitation, PatientConditions.Chronic, PatientConditions.Critical, PatientConditions.PostOperative};
        public PatientFaker() 
        {
            RuleFor(p => p.Id, Guid.NewGuid());
            RuleFor(p => p.PatientFName, f => f.Person.FirstName);
            RuleFor(p => p.PatientLName, f => f.Person.LastName);
            RuleFor(p => p.Phone, f => f.Phone.PhoneNumber());
            RuleFor(p => p.BloodType, f => PatientConditions.BloodTypes.ElementAt(f.Random.Number(0, PatientConditions.BloodTypes.Count() - 1)));
            RuleFor(p => p.Email, f => f.Person.Email);
            RuleFor(p => p.Gender, f => f.Person.Gender.ToString());
            RuleFor(p => p.Condition, f => Conditions[f.Random.Int(0, Conditions.Length - 1)]);
            RuleFor(p => p.AdmissionDate, f=> f.Date.Past());
            RuleFor(p => p.DischargeTime, f => f.Date.Recent());
        }
    }
}
