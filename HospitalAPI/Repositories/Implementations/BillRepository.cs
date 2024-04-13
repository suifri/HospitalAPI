using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories.Implementations
{
    public class BillRepository(HospitalContext context) : BaseRepository<Bill>(context), IBillRepository
    {
    }
}
