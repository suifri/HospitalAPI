using HospitalAPI.Constants;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BillController(IBillRepository billRepository) : ControllerBase
    {
        [Authorize(Roles = $"{RoleNames.Administrator}")]
        [HttpGet]
        public async Task<IEnumerable<Bill>> Get()
        {
            return await billRepository.GetAll();
        }

        [Authorize(Roles = $"{RoleNames.Administrator},{RoleNames.Patient}")]
        [HttpGet]
        public async Task<IEnumerable<Bill>> GetByPatientId(Guid id)
        {
            return await billRepository.Find(x => x.PatientId == id);
        }

        [Authorize(Roles = $"{RoleNames.Administrator},{RoleNames.Doctor}")]
        [HttpPost]
        public async Task<IActionResult> Add(Bill bill)
        {
            await billRepository.Add(bill);
            await billRepository.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = $"{RoleNames.Administrator},{RoleNames.Doctor}")]
        [HttpPatch]
        public async Task<IActionResult> Update(Bill bill)
        {
            billRepository.Update(bill);
            await billRepository.SaveChanges();

            return Ok();
        }
    }
}
