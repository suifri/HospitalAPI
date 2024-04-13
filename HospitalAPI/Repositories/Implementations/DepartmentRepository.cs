using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories.Implementations
{
    public class DepartmentRepository(HospitalContext context) : BaseRepository<Department>(context), IDepartmentRepository
    {
    }
}
