using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories.Implementations
{
    public class MedicineRepository(HospitalContext context) : BaseRepository<Medicine>(context), IMedicineRepository 
    {
    }
}
