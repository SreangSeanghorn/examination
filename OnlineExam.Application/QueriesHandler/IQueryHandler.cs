using OnlineExam.Application.Queries;

namespace OnlineExam.Application.QueriesHandler
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
         Task<TResult> Handle(TQuery query);
    }
}