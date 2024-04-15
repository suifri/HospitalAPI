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
    public class SeederController(IPatientRepository _patientRepository,
        IAppointmentRepository appointmentRepository,
        IBillRepository billRepository,
        IDepartmentRepository departmentRepository,
        IDoctorRepository doctorRepository,
        IInsuranceRepository insuranceRepository,
        IMedicineRepository medicineRepository,
        IPayrollRepository payrollRepository,
        IPrescriptionRepository prescriptionRepository,
        IRoomRepository roomRepository,
        IStaffRepository staffRepository,
        IScheduleRepository scheduleRepository) : ControllerBase
    {
        [HttpPut(Name = "Seed patient table")]
        public async Task<IActionResult> SeedPatientTable()
        {

            List<Patient> patients = new List<Patient>();
            List<Insurance> insurances = new List<Insurance>();
            List<Bill> bills = new List<Bill>();
            List<RoomPatients> roomPatients = new List<RoomPatients>();

            for (int i = 0; i < 2840; ++i)
            {
                patients.Add(new PatientFaker());
                insurances.Add(new InsuranceFaker());
                insurances.ElementAt(i).PatientId = patients.ElementAt(i).Id;
            }

            List<Room> rooms = [];


            int k = 0;

            for (int i = 0; i < 284; ++i)
            {
                var roomId = Guid.NewGuid();

                var roomPatientss = new List<RoomPatients>();

                for(int j = k; j < k + 10; ++j)
                {
                    roomPatientss.Add(new Faker<RoomPatients>()
                        .RuleFor(x => x.RoomId, f => roomId)
                        .RuleFor(x => x.PatientId, patients.ElementAt(j).Id));
                }

                k += 10;

                rooms.Add(new Faker<Room>()
                    .RuleFor(x => x.Id, f => roomId)
                    .RuleFor(r => r.Type, f => f.PickRandom(RoomFaker.types))
                    .RuleFor(r => r.Cost, f => f.Random.Decimal(50, 500))
                    .RuleFor(x => x.RoomPatients, f => roomPatientss));

            }

            for (int i = 0; i < 4201; ++i)
                bills.Add(
                    new Faker<Bill>()
                    .RuleFor(b => b.Id, Guid.NewGuid())
                    .RuleFor(b => b.Date, f => f.Date.Past())
                    .RuleFor(b => b.RoomCost, f => f.Random.Decimal(100, 500))
                    .RuleFor(b => b.TestCost, f => f.Random.Decimal(50, 200))
                    .RuleFor(b => b.OtherCharges, f => f.Random.Decimal(10, 50))
                    .RuleFor(b => b.MedicineCost, f => f.Random.Decimal(50, 200))
                    .RuleFor(b => b.PatientId, f => f.PickRandom(patients).Id));

            List<Department> departments = new List<Department>();

            for(int i = 0; i < 74; ++i)
                departments.Add(new DepartmentFaker());

            List<Staff> staffs = new List<Staff>();
            List<Payroll> payrolls = new List<Payroll>();
            List<Doctor> doctors = new List<Doctor>();
            List<Schedule> schedules = new List<Schedule>();

            for (int i = 0; i < 1488; ++i)
            {
                staffs.Add(new StaffFaker());
                staffs[i].DepartmentId = new Faker().PickRandom(departments).Id;
                payrolls.Add(new PayrollFaker());
                payrolls[i].StaffId = staffs[i].Id;

                if (i < 872)
                {
                    doctors.Add(new DoctorFaker());
                    doctors[i].StaffId = staffs[i].Id;
                    schedules.Add(new SchedulesFaker());
                    schedules[i].DoctorId = doctors[i].Id;
                }
            }

            List<Appointment> appointments = new List<Appointment>();

            for (int i = 0; i < 5642; ++i)
            {
                appointments.Add(new AppointmentFaker());

                appointments[i].DoctorId = new Faker().PickRandom(doctors).Id;
                appointments[i].PatientId = new Faker().PickRandom(patients).Id;
            }

            List<Medicine> medicines = new List<Medicine>();

            for (int i = 0; i < 2340; ++i)
                medicines.Add(new MedicineFaker());

            List<Prescription> prescriptions = new List<Prescription>();

            for (int i = 0; i < 5718; ++i)
            {
                prescriptions.Add(new PrescriptionFaker());

                prescriptions[i].DoctorId = new Faker().PickRandom(doctors).Id;
                prescriptions[i].MedicineId = new Faker().PickRandom(medicines).Id;
                prescriptions[i].PatientId = new Faker().PickRandom(patients).Id;
            }



            await _patientRepository.AddRange(patients);
            await _patientRepository.SaveChanges();

            await roomRepository.AddRange(rooms);
            await roomRepository.SaveChanges();



            await insuranceRepository.AddRange(insurances);
            await insuranceRepository.SaveChanges();    

            await billRepository.AddRange(bills);
            await billRepository.SaveChanges();

            await departmentRepository.AddRange(departments);
            await departmentRepository.SaveChanges();

            await staffRepository.AddRange(staffs);
            await staffRepository.SaveChanges();

            await payrollRepository.AddRange(payrolls);
            await payrollRepository.SaveChanges();

            await doctorRepository.AddRange(doctors);
            await doctorRepository.SaveChanges();

            await appointmentRepository.AddRange(appointments);
            await appointmentRepository.SaveChanges();

            await medicineRepository.AddRange(medicines);
            await medicineRepository.SaveChanges();

            await prescriptionRepository.AddRange(prescriptions);
            await prescriptionRepository.SaveChanges();

            await scheduleRepository.AddRange(schedules);
            await scheduleRepository.SaveChanges();

            return Ok();
        }

    }
}
