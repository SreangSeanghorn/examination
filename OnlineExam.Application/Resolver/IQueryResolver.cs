using OnlineExam.Application.Queries;

namespace OnlineExam.Application;

public interface IQueryResolver
{
    Task<TResult> ResolveHandler<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;

}
