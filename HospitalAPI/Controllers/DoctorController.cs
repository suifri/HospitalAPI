using HospitalAPI.DTO;
using HospitalAPI.Mappers;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DoctorController(IDoctorRepository doctorRepository, IDepartmentRepository departmentRepository,
        IScheduleRepository scheduleRepository, IStaffRepository staffRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<List<DoctorResponseDTO>> GetAll()
        {
            List<DoctorResponseDTO> doctors = new List<DoctorResponseDTO>();

            var values = await doctorRepository.GetAll();

            foreach (var i in values)
                doctors.Add(DoctorResponseMapper.Doctor2Response(i));

            return doctors;
        }

        [HttpGet]
        public async Task<IEnumerable<Doctor>> GetByEmail(string email)
        {
            return await doctorRepository.Find(x => x.Staff_.Email == email);
        }

        [HttpGet]
        public DoctorResponseDTO GetById(Guid id)
        {
            var test = doctorRepository.Find(x => x.Id == id).Result.First();
            return DoctorResponseMapper.Doctor2Response(test);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(DoctorRequestDTO doctor)
        {
            var test = doctorRepository.Find(x => x.Id == doctor.Id).Result.First();

            test.Qualifications = doctor.Qualifications;
            test.Specialization = doctor.Specialization;

            test.Staff_.Address = doctor.Address;
            test.Staff_.Email = doctor.Email;
            test.Staff_.EmpFName = doctor.EmpFName;
            test.Staff_.EmpLName = doctor.EmpLName;
            test.Staff_.SSN = int.Parse(doctor.SSN);

            var date = doctor.DateJoining.Split('/');

            test.Staff_.DateJoining = new DateOnly(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
            test.Staff_.EmpType = doctor.EmpType;

            var scedule = scheduleRepository.Find(x => x.Id == test.ScheduleId).Result.First();

            var newSceduleValues = scheduleRepository.Find(x => x.Id == doctor.ScheduleId).Result.First();

            scedule.StartHour = newSceduleValues.StartHour;
            scedule.EndHour = newSceduleValues.EndHour;

            doctorRepository.Update(test);
            await doctorRepository.SaveChanges();

            scheduleRepository.Update(scedule);
            await doctorRepository.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DoctorRequestDTO doctor)
        {
            var date = doctor.DateJoining.Split('/');

            var staff = new Staff { Address = doctor.Address, 
                DateJoining = new DateOnly(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])),
                DateSeparation = DateOnly.MaxValue,
                DepartmentId = doctor.DepartmentID,
                Email = doctor.Email,
                EmpFName = doctor.EmpFName,
                EmpLName = doctor.EmpLName,
                EmpType = doctor.EmpType,
                SSN = int.Parse(doctor.SSN),
                Id = Guid.NewGuid(),
            };

            await staffRepository.Add(staff);
            await staffRepository.SaveChanges();

            var doc = new Doctor
            {
                Id = Guid.NewGuid(),
                StaffId = staff.Id,
                Qualifications = doctor.Qualifications,
                Specialization = doctor.Specialization,
            };

            var oldSchedule = scheduleRepository.Find(x => x.Id == doctor.ScheduleId).Result.First();

            var schedule = new Schedule
            {
                DoctorId = doc.Id,
                Id = Guid.NewGuid(),
                StartHour = oldSchedule.StartHour,
                EndHour = oldSchedule.EndHour,
            };

            doc.ScheduleId = schedule.Id;

            await doctorRepository.Add(doc);
            await doctorRepository.SaveChanges();

            await scheduleRepository.Add(schedule);
            await scheduleRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var doc = doctorRepository.Find(x => x.Id == id).Result.First();
            doctorRepository.Remove(doc);
            await doctorRepository.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> GetAllDepartments() => await departmentRepository.GetAll();

        [HttpGet]
        public async Task<IEnumerable<Schedule>> GetAllSchedules() => await scheduleRepository.GetAll();
    }
}
