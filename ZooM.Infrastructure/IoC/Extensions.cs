using Microsoft.Extensions.DependencyInjection;
using ZooM.Application.Commands;
using ZooM.Application.Commands.Employees;
using ZooM.Infrastructure.IoC.Employee;

namespace ZooM.Infrastructure.IoC
{
    internal static class Extensions
    {
        public static void AddDecorators(this IServiceCollection services)
        {
            services.Decorate<ICommandHandler<CreateEmployee>, CreateEmployeeDecorator>();
            services.Decorate<ICommandHandler<UpdateEmployee>, UpdateEmployeeDecorator>();
            services.Decorate<ICommandHandler<DeleteEmployee>, DeleteEmployeeDecorator>();
        }
    }
}
