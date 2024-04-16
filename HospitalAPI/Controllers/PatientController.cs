using HospitalAPI.DTO;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PatientController(IPatientRepository patientRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Patient>> Get([FromQuery] RequestDTO<Patient> input)
        {
            //var query = await patientRepository.GetAll();

            //query = query.OrderBy($"{input.SortColumn} {input.SortOrder}")

        }
    }
}
