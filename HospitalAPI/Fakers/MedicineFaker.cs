using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class MedicineFaker : Faker<Medicine>
    {
        public MedicineFaker() 
        {
            RuleFor(m => m.Id, f => Guid.NewGuid());
            RuleFor(m => m.MName, f => f.Commerce.ProductName());// add medicine names
            RuleFor(m => m.MQuantity, f => f.Random.Number(1, 56));
            RuleFor(m => m.MCost, f => f.Random.Decimal(1, 1234));
        }
    }
}
