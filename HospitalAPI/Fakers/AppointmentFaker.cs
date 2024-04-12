using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class AppointmentFaker : Faker<Appointment>
    {
        public AppointmentFaker() 
        {
            RuleFor(a => a.Id, Guid.NewGuid());
            RuleFor(a => a.ScheduledOn, f => f.Date.Future());
            RuleFor(a => a.Date, f => f.Date.FutureDateOnly());
            RuleFor(a => a.Time, f => TimeOnly.FromTimeSpan(f.Date.Timespan()));
           // RuleFor(a => , f =>);
           // RuleFor(a => , f =>);
        }
    }
}
