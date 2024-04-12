using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class RoomFaker : Faker<Room>
    {
        public RoomFaker() 
        {
            RuleFor(r => r.Type, f => f.Random.Word());
            RuleFor(r => r.Cost, f => f.Random.Decimal(50, 500));
            //RuleFor(r => , f =>);
        }
    }
}
