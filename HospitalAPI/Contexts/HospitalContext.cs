using HospitalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Contexts
{
    public class HospitalContext(DbContextOptions<HospitalContext> options) : DbContext(options)
    {
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Bill> Bills => Set<Bill>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Insurance> Insurances => Set<Insurance>();
        public DbSet<Medicine> Medicines => Set<Medicine>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Payroll> Payrolls => Set<Payroll>();
        public DbSet<Prescription> Prescriptions => Set<Prescription>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Staff> Staff_ => Set<Staff>();
    }
}
