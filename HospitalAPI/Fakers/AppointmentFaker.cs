using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class AppointmentFaker : Faker<Appointment>
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public AppointmentFaker() 
        {
            RuleFor(a => a.Id, Guid.NewGuid());
            RuleFor(a => a.ScheduledOn, f => f.Date.Future());
            RuleFor(a => a.Date, f => f.Date.FutureDateOnly());
            RuleFor(a => a.Time, f => f.Date.BetweenTimeOnly(new TimeOnly(0, 0), new TimeOnly(23, 59)));
            RuleFor(a => a.DoctorId, f => DoctorId);
            RuleFor(a => a.PatientId, f => PatientId);
        }
    }
}
