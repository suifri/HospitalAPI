using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories.Implementations
{
    public class DoctorRepository(HospitalContext context) : BaseRepository<Doctor>(context), IDoctorRepository 
    {
    }
}
