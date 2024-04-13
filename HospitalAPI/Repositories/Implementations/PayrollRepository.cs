using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories.Implementations
{
    public class PayrollRepository(HospitalContext context) : BaseRepository<Payroll>(context), IPayrollRepository
    {
    }
}
