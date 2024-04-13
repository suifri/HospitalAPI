using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories.Implementations
{
    public class RoomRepository(HospitalContext context) : BaseRepository<Room>(context), IRoomRepository 
    {
    }
}
