using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class RoomFaker : Faker<Room>
    {
        public static IEnumerable<string> types = new string[] { "Emergency", "Operating", "Intensive Care", "General Ward", "Maternity Ward", "Pediatric Ward", "Radiology" };

        public Guid patientGuid { get; set; }

        public RoomFaker() 
        {
            RuleFor(r => r.Id, Guid.NewGuid());
            RuleFor(r => r.Type, f => types.ElementAt(f.Random.Number(0, types.Count() - 1)));
            RuleFor(r => r.Cost, f => f.Random.Decimal(50, 500));
        }
    }
}
