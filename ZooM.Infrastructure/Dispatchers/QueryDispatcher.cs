using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ZooM.Application.Queries;
using ZooM.Application.Queries.Dispatchers;


namespace ZooM.Infrastructure.Dispatchers
{
    internal class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = _serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();
            return handler.HandleAsync(query);
        }
    }
}
