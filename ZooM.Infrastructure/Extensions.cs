using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ZooM.Infrastructure.Databases;
using ZooM.Infrastructure.Dispatchers;
using ZooM.Infrastructure.Queries.Handlers;
using ZooM.Infrastructure.Repositories;

namespace ZooM.Infrastructure
{
    public static class Extensions
    {
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddDispatchers();
            services.AddQueryHandlers();
            services.AddRepositories();
            services.AddDatabase();
        }
        public static void UseInfrastructure(this IApplicationBuilder app)
        {
        }
}

}
