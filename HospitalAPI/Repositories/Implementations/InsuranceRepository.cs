using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories.Implementations
{
    public class InsuranceRepository(HospitalContext context) : BaseRepository<Insurance>(context), IInsuranceRepository
    {
    }
}
