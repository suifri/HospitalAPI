using HospitalAPI.DTO;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AppointmentController(IAppointmentRepository appointmentRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<AppointmentDoctorResponseDTO>> GetByDoctorEmail(string email)
        {

            var doc = doctorRepository.Find(x => x.Staff_.Email == email).Result.First();

            var appointments =  appointmentRepository.Find(x => x.DoctorId == doc.Id).Result;

            List<AppointmentDoctorResponseDTO> appointmentDoctorResponseDTOs = new List<AppointmentDoctorResponseDTO>();

            foreach (var i in appointments)
                appointmentDoctorResponseDTOs.Add(new AppointmentDoctorResponseDTO { Date = i.Date, PatientName = i.Patient_.PatientFName + " " + i.Patient_.PatientLName, Time = i.Time });

            return appointmentDoctorResponseDTOs;
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

        [HttpPost]
        public async Task<IActionResult> AddReal(RequestAppointmentDTO request)
        {
            var patient = patientRepository.Find(x => x.Email == request.PatientEmail).Result.First();
            var doc = doctorRepository.Find(x => x.Staff_.EmpFName + " " + x.Staff_.EmpLName == request.DoctorName).Result.First();

            var docAppointments = await appointmentRepository.Find(x => x.DoctorId == doc.Id);

            var dates = request.Date.Split('/');

            for (int i = 0; i < docAppointments.Count() - 1; ++i)
                if (docAppointments.ElementAt(i).Time == new TimeOnly(int.Parse(request.Time), 0, 0) && docAppointments.ElementAt(i).Date == new DateOnly(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2])))
                    return BadRequest();



            await appointmentRepository.Add(new Appointment { Date = new DateOnly(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2])), DoctorId = doc.Id,
                Id = Guid.NewGuid(), PatientId = patient.Id, Time = new TimeOnly(int.Parse(request.Time), 0, 0) , ScheduledOn = new DateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]), int.Parse(request.Time), 0, 0)});
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
