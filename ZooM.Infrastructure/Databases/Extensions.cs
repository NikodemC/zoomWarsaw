using Microsoft.Extensions.DependencyInjection;
using ZooM.Infrastructure.Databases.NHibernate;
using ZooM.Infrastructure.Options;

namespace ZooM.Infrastructure.Databases
{
    internal static class Extensions
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddOption<DatabaseOptions>("Database");
            services.AddNHibernate();
        }
    }
}
