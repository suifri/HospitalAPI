using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AppointmentController(IAppointmentRepository appointmentRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Appointment>> GetByDoctorId(Guid doctorId)
        {
            return await appointmentRepository.Find(x => x.DoctorId == doctorId);
        }

        [HttpGet]
        public async Task<IEnumerable<Appointment>> GetByPatientId(Guid patientId)
        {
            return await appointmentRepository.Find(x => x.PatientId == patientId);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Appointment appointment)
        {
            await appointmentRepository.Add(appointment);
            await appointmentRepository.SaveChanges();

            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Update(Appointment appointment)
        {
            appointmentRepository.Update(appointment);
            await appointmentRepository.SaveChanges();

            return Ok();
        }
    }
}
