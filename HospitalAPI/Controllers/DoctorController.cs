using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DoctorController(IDoctorRepository doctorRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await doctorRepository.GetAll();
        }

        [HttpGet]
        public async Task<IEnumerable<Doctor>> GetByEmail(string email)
        {
            return await doctorRepository.Find(x => x.Staff_.Email == email);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Doctor doctor)
        {
            await doctorRepository.Add(doctor);
            await doctorRepository.SaveChanges();

            return Ok();
        }
    }
}
