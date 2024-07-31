using OnlineExam.Application.Commands;
namespace OnlineExam.Infrastructure.Resolver
{
    public interface ICommandResolver
    {
          Task<TResult> ResolveHandler<TCommand, TResult>(TCommand command)
           where TCommand : ICommand<TResult>;
    }
}