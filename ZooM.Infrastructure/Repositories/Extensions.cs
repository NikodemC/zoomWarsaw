using Microsoft.Extensions.DependencyInjection;
using ZooM.Core.Repositories;

namespace ZooM.Infrastructure.Repositories
{
    internal static class Extensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAnimalRepository, AnimalDatabaseRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeDatabaseRepository>();
            services.AddTransient<IAnimalActionRepository, AnimalActionDatabaseRepository>();
            services.AddTransient<IAreaRepository, AreaDatabaseRepository>();
        }
    }
}
