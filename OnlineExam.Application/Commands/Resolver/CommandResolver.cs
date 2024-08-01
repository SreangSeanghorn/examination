using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OnlineExam.Application.CommandHandler;
using OnlineExam.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineExam.Infrastructure.Resolver
{
    public class CommandResolver : ICommandResolver
    {
        private readonly IServiceProvider _serviceProvider;
        
        public CommandResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> ResolveHandler<TCommand, TResult>(TCommand command)
         where TCommand : ICommand<TResult>
        {
            var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand, TResult>));
            if (handler == null)
            {
                throw new InvalidOperationException($"Handler for {typeof(TCommand).Name} not found");
            }
             return await ((ICommandHandler<TCommand, TResult>)handler).Handle(command, default);
        }
    }
   
}