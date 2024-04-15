using HospitalAPI.Repositories.Implementations;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.DIContainers
{
    public static class RepositoryInjector
    {
        public static IServiceCollection AddRepositoriesInjection(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IMedicineRepository, MedicineRepository>();
            services.AddScoped<IPayrollRepository, PayrollRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IRoomPatientRepository, RoomPatientRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            return services;
        }
    }
}
