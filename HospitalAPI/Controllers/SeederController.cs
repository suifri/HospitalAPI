using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bogus;
using HospitalAPI.Models;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SeederController(Faker _faker) : ControllerBase
    {
        [HttpPut(Name = "Seed patient table")]
        public async Task<IActionResult> SeedPatientTable()
        {
            var patient = new Patient
            {
                Id = Guid.NewGuid(),
                PatientFName = _faker.Person.FirstName,
                PatientLName = _faker.Person.LastName,
                Phone = _faker.Phone.PhoneNumber(),
                BloodType = _faker.Random.String(2, 'A', 'B'),
                Email = _faker.Person.Email,
                Gender = _faker.Person.Gender.ToString(),
                Condition = _faker.Lorem.Word(),
                AdmissionDate = _faker.Date.Past(),
                DischargeTime = _faker.Date.Recent(),
            };

            return Ok();
        }

    }
}
