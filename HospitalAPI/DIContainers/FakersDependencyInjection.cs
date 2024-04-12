using HospitalAPI.Fakers;

namespace HospitalAPI.DIContainers
{
    public static class FakersDependencyInjection
    {
        public static IServiceCollection AddFakersDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<PatientFaker>();
            return services;
        }
    }
}
