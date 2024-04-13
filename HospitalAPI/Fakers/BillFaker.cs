using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class BillFaker : Faker<Bill>
    {
        public Guid PatientId { get; set; }
        public BillFaker() 
        {
            RuleFor(b => b.Id, Guid.NewGuid());
            RuleFor(b => b.Date, f => f.Date.Past());
            RuleFor(b => b.RoomCost, f => f.Random.Decimal(100, 500));
            RuleFor(b => b.TestCost, f => f.Random.Decimal(50, 200));
            RuleFor(b => b.OtherCharges, f => f.Random.Decimal(10, 50));
            RuleFor(b => b.MedicineCost, f => f.Random.Decimal(50, 200));
            RuleFor(b => b.PatientId, PatientId);
        }
    }
}
