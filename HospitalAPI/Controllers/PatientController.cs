using HospitalAPI.Constants;
using HospitalAPI.DTO;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using System.Numerics;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PatientController(IPatientRepository patientRepository, UserManager<HospitalUser> userManager) : ControllerBase
    {
        //[Authorize(Roles = $"{RoleNames.Doctor},{RoleNames.Administrator}")]
        [HttpGet]
        public async Task<IEnumerable<Patient>> Get()
        {
            return await patientRepository.GetAll();
        }

        //[Authorize(Roles = $"{RoleNames.Patient},{RoleNames.Doctor},{RoleNames.Administrator}")]
        [HttpGet]
        public async Task<Patient> GetByEmail(string email)
        {
            return patientRepository.Find(x => x.Email == email).Result.First();
        }

        [HttpPost]
        public async Task<IActionResult> AddByDTO(RequestPatientDTO patient)
        {
            var pat = new Patient()
            {
                Id = Guid.NewGuid(),
                AdmissionDate = DateTime.Now,
                BloodType = patient.BloodType,
                Condition = patient.Condition,
                Diagnosis = string.Empty,
                Email = patient.Email,
                Gender = patient.Gender,
                PatientFName = patient.PatientFName,
                PatientLName = patient.PatientLName,
                Phone = patient.Phone,
                Rhesus = patient.Rhesus,
            };

            await patientRepository.Add(pat);
            await patientRepository.SaveChanges();

            var user = new HospitalUser();
            user.UserName = patient.PatientFName + patient.PatientLName;
            user.Email = patient.Email;

            var result = await userManager.CreateAsync(user, patient.Password);

            var search = await userManager.FindByEmailAsync(user.Email);

            if (search is not null)
                await userManager.AddToRoleAsync(search, RoleNames.Patient);

            return Ok();
        }

        [HttpGet]
        public Patient GetById(Guid id)
        {
            return patientRepository.Find(x => x.Id == id).Result.First();
        }

        [Authorize(Roles = $"{RoleNames.Patient},{RoleNames.Doctor},{RoleNames.Administrator}")]
        [HttpPost]
        public async Task<IActionResult> Add(Patient patient)
        {
            await patientRepository.Add(patient);
            await patientRepository.SaveChanges();
            return Ok();
        }

        //[Authorize(Roles = $"{RoleNames.Patient},{RoleNames.Doctor}")]
        [HttpPatch]
        public async Task<IActionResult> Update(PatientRequestDTO patient)
        {

            var realPatient = patientRepository.Find(x => x.Id == patient.Id).Result.First();

            realPatient.Email = patient.Email;
            realPatient.PatientFName = patient.PatientFName;
            realPatient.PatientLName = patient.PatientLName;
            realPatient.Gender = patient.Gender;
            realPatient.Phone = patient.Phone;
            var date = patient.AdmissionDate.Split('/');

            realPatient.AdmissionDate = DateTime.ParseExact(patient.AdmissionDate, "yyyy-MM-ddTHH:mm:ss.fffffff", System.Globalization.CultureInfo.InvariantCulture); ;

            patientRepository.Update(realPatient);
            await patientRepository.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var entity = patientRepository.Find(x => x.Id == id).Result.First();

            patientRepository.Remove(entity);
            await patientRepository.SaveChanges();

            return Ok();
        }
    }
}
