using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories.Implementations
{
    public class AppointmentRepository(HospitalContext context) : BaseRepository<Appointment>(context), IAppointmentRepository
    {
    }
}
