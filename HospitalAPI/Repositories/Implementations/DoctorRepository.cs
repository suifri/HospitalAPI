using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories.Implementations
{
    public class DoctorRepository(HospitalContext context) : BaseRepository<Doctor>(context), IDoctorRepository 
    {
        public override async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _context.Doctors.Include(x => x.Staff_).ToListAsync();
        }
    }
}
