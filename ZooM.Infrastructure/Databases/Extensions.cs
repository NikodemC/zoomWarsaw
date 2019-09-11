using Microsoft.Extensions.DependencyInjection;

namespace ZooM.Infrastructure.Databases
{
    internal static class Extensions
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            // services.AddOption<DatabaseOptions>("Database");
           // services.AddNHibernate();
        }
    }
}
