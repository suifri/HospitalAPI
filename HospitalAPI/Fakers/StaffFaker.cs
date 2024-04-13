using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class StaffFaker : Faker<Staff>
    {
        private IEnumerable<string> strings = new string[] { "Physician",
    "Surgeon",
    "Nurse",
    "Anesthesiologist",
    "Pediatrician",
    "Obstetrician",
    "Gynecologist",
    "Cardiologist",
    "Neurologist",
    "Radiologist",
    "Pathologist",
    "Dermatologist",
    "Oncologist",
    "Psychiatrist",
    "Orthopedist",
    "Ophthalmologist",
    "Otolaryngologist",
    "Urologist",
    "Gastroenterologist",
    "Endocrinologist",
    "Pulmonologist",
    "Allergist",
    "Rheumatologist",
    "Hematologist"};

        public Guid Guid_ { get; set; }
        public StaffFaker() 
        {
            RuleFor(s => s.Id, Guid.NewGuid());
            RuleFor(s => s.EmpFName, f => f.Person.FirstName);
            RuleFor(s => s.EmpLName, f => f.Person.LastName);

            RuleFor(s => s.DateJoining, f => f.Date.PastDateOnly());
            RuleFor(s => s.DateSeparation, f => f.Date.FutureDateOnly());
            RuleFor(s => s.EmpType, f => strings.ElementAt(f.Random.Number(0, strings.Count() - 1)));
            RuleFor(s => s.Email, f => f.Person.Email);
            RuleFor(s => s.Address, f => f.Address.FullAddress());
            RuleFor(s => s.SSN, f => f.Random.Number(100000000, 999999999));
            RuleFor(s => s.DepartmentId, Guid_);
        }
    }
}
