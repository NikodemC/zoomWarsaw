using Microsoft.Extensions.DependencyInjection;

namespace ZooM.Infrastructure.Databases.NHibernate
{
    internal static class Extensions
    {
        public static void AddNHibernate(this IServiceCollection services)
        {
            services.AddSingleton<AppSessionFactory>();
            services.AddTransient(sp => sp.GetService<AppSessionFactory>().OpenSession());
            services.AddTransient(typeof(IRepository<>), typeof(NHibernateRepository<>));
        }
    }
}
