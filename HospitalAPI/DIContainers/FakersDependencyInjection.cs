using HospitalAPI.Fakers;

namespace HospitalAPI.DIContainers
{
    public static class FakersDependencyInjection
    {
        public static IServiceCollection AddFakersDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<PatientFaker>();
            services.AddSingleton<AppointmentFaker>();
            services.AddSingleton<BillFaker>();
            services.AddSingleton<DepartmentFaker>();
            services.AddSingleton<DoctorFaker>();
            services.AddSingleton<InsuranceFaker>();
            services.AddSingleton<MedicineFaker>();
            services.AddSingleton<PayrollFaker>();
            services.AddSingleton<PrescriptionFaker>();
            services.AddSingleton<RoomFaker>();
            services.AddSingleton<StaffFaker>();
            return services;
        }
    }
}
