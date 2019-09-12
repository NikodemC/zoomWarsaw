using System.Threading.Tasks;

namespace ZooM.Application.Queries.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
