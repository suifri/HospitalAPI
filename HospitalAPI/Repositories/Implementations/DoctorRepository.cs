using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HospitalAPI.Repositories.Implementations
{
    public class DoctorRepository(HospitalContext context) : BaseRepository<Doctor>(context), IDoctorRepository 
    {
        public override async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _context.Doctors.Include(x => x.Staff_).ToListAsync();
        }

        public override async Task<IEnumerable<Doctor>> Find(Expression<Func<Doctor, bool>> predicate)
        {
            return await _context.Doctors.Include(x => x.Staff_).Where(predicate).ToListAsync();
        }
    }
}
