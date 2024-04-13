using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class PayrollFaker : Faker<Payroll>
    {
        public Guid Id { get; set; }
        public PayrollFaker()
        {
            RuleFor(p => p.AccountNo, f => f.Finance.Account());
            RuleFor(p => p.Salary, f => f.Random.Decimal(1000, 10000));
            RuleFor(p => p.Bonus, f => f.Random.Decimal(0, 1000));
            RuleFor(p => p.IBAN, f => f.Finance.Iban());
            RuleFor(p => p.StaffId, Id);
        }
    }
}
