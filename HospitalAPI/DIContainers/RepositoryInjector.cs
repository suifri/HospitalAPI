using HospitalAPI.Repositories.Implementations;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.DIContainers
{
    public static class RepositoryInjector
    {
        public static IServiceCollection AddRepositoriesInjection(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();

            return services;
        }
    }
}
