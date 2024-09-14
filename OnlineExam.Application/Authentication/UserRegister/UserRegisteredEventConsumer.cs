using System;
using MassTransit;
using OnlineExam.Domain.Entities.Users;

namespace OnlineExam.Application.Authentication.UserRegister;

public class UserRegisteredEventConsumer : IConsumer<UserRegisteredEvent>
{
    public Task Consume(ConsumeContext<UserRegisteredEvent> context)
    {
        var @event = context.Message;
        Console.WriteLine($"User Registered Event: {@event.EntityId},Email: {@event.Content.Email}, Name: {@event.Content.Name}");
        return Task.CompletedTask;
    }
}
