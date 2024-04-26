using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HospitalAPI.Repositories.Implementations
{
    public class AppointmentRepository(HospitalContext context) : BaseRepository<Appointment>(context), IAppointmentRepository
    {
        public override async Task<IEnumerable<Appointment>> Find(Expression<Func<Appointment, bool>> predicate)
        {
            return await _context.Appointments.Include(x => x.Patient_).Where(predicate).ToListAsync();
        }
    }
}
