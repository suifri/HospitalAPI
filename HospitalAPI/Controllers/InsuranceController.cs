using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class InsuranceController(IInsuranceRepository insuranceRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Insurance>> GetByPatientId(Guid id)
        {
            return await insuranceRepository.Find(x => x.PatientId == id);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Insurance insurance)
        {
            await insuranceRepository.Add(insurance);
            await insuranceRepository.SaveChanges();

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Update(Insurance insurance)
        {
            insuranceRepository.Update(insurance);
            await insuranceRepository.SaveChanges();

            return Ok();
        }
    }
}
