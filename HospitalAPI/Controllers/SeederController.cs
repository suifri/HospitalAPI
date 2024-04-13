using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bogus;
using HospitalAPI.Models;
using HospitalAPI.Fakers;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SeederController(IPatientRepository _patientRepository) : ControllerBase
    {
        [HttpPut(Name = "Seed patient table")]
        public async Task<IActionResult> SeedPatientTable()
        {
            List<Patient> patients = new List<Patient>();

            for(int i = 0; i < 2345; ++i)
            {
                patients.Add(new PatientFaker());
            }

            await _patientRepository.AddRange(patients);
            await _patientRepository.SaveChanges();

            return Ok();
        }

    }
}
