using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class SchedulesFaker : Faker<Schedule>
    {
        public SchedulesFaker() 
        {
            RuleFor(s => s.Id, f => Guid.NewGuid());
            RuleFor(s => s.StartHour, f => f.Date.BetweenTimeOnly(new TimeOnly(0, 0), new TimeOnly(23, 59)));
            RuleFor(s => s.EndHour, f => f.Date.BetweenTimeOnly(new TimeOnly(0, 0), new TimeOnly(23, 59)));
        }
    }
}
