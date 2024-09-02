using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Application.Queries;
using OnlineExam.Application.QueriesHandler;

namespace OnlineExam.Application;

public class QueryResolver : IQueryResolver
{
    private readonly IServiceProvider _serviceProvider;
    public QueryResolver(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResult> ResolveHandler<TQuery, TResult>(TQuery query ) where TQuery : IQuery<TResult>
    {
        var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
        return handler.Handle(query);
    }
}
