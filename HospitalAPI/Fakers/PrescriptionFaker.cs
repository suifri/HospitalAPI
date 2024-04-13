using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class PrescriptionFaker : Faker<Prescription>
    {
        public Guid PatientId { get; set; }
        public Guid MedicineId { get; set; }
        public Guid DoctorID { get; set; }

        public PrescriptionFaker()
        {
            RuleFor(p => p.Id, Guid.NewGuid());
            RuleFor(p => p.Date, f => f.Date.Past());
            RuleFor(p => p.Dosage, f => f.Random.Number(1, 12));
            RuleFor(p => p.PatientId, PatientId);
            RuleFor(p => p.MedicineId, MedicineId);
            RuleFor(p => p.DoctorId, DoctorID);
        }
    }
}
