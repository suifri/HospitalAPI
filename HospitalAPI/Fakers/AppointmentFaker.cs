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
            RuleFor(a => a.Time, f => TimeOnly.FromTimeSpan(f.Date.Timespan()));
            RuleFor(a => a.DoctorId, f => DoctorId);
            RuleFor(a => a.PatientId, f => PatientId);
        }
    }
}
