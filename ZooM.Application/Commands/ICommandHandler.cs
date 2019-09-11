using System.Threading.Tasks;

namespace ZooM.Application.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
