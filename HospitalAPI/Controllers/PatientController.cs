using HospitalAPI.Constants;
using HospitalAPI.DTO;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PatientController(IPatientRepository patientRepository) : ControllerBase
    {
        [Authorize(Roles = $"{RoleNames.Doctor},{RoleNames.Administrator}")]
        [HttpGet]
        public async Task<IEnumerable<Patient>> Get()
        {
            return await patientRepository.GetAll();
        }

        [Authorize(Roles = $"{RoleNames.Patient},{RoleNames.Doctor},{RoleNames.Administrator}")]
        [HttpGet]
        public async Task<IEnumerable<Patient>> GetByEmail(string email)
        {
            return await patientRepository.Find(x => x.Email == email);
        }

        [Authorize(Roles = $"{RoleNames.Patient},{RoleNames.Doctor},{RoleNames.Administrator}")]
        [HttpPost]
        public async Task<IActionResult> Add(Patient patient)
        {
            await patientRepository.Add(patient);
            await patientRepository.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = $"{RoleNames.Patient},{RoleNames.Doctor}")]
        [HttpPatch]
        public async Task<IActionResult> Update(Patient patient)
        {
            patientRepository.Update(patient);
            await patientRepository.SaveChanges();
            return Ok();
        }
    }
}
