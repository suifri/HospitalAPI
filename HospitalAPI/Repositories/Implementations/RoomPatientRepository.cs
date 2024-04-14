using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories.Implementations
{
    public class RoomPatientRepository(HospitalContext context) : BaseRepository<RoomPatients>(context), IRoomPatientRepository
    {
    }
}
