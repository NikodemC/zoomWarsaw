using Microsoft.Extensions.DependencyInjection;

namespace ZooM.Application.Commands
{
    internal static class Extensions
    {
        public static void AddCommandHandlers(this IServiceCollection services)
        {
            var servicesList = services.Scan(scan =>
            {
                scan.FromAssemblyOf<ICommand>()
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }
    }
}
