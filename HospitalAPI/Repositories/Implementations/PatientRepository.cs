using HospitalAPI.Contexts;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HospitalAPI.Repositories.Implementations
{
    public class PatientRepository(HospitalContext context) : BaseRepository<Patient>(context), IPatientRepository
    {
        
    }
}
