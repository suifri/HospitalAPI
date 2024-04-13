using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories.Implementations
{
    public class PrescriptionRepository(HospitalContext context) : BaseRepository<Prescription>(context), IPrescriptionRepository
    {

    }
}
