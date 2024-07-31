using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OnlineExam.Application.Commands;

namespace OnlineExam.Application.CommandHandler
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
    {
      
    }
   public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    {
        Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
    }
}