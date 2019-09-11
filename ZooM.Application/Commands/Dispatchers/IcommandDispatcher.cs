using System.Threading.Tasks;

namespace ZooM.Application.Commands.Dispatchers
{

    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
