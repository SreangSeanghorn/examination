using System;
using MassTransit;
using OnlineExam.Domain.Interfaces;

namespace OnlineExam.Infrastructure.MessageBroker;

public class KafkaEventPublisher : IEventPublisher
{
    private readonly IPublishEndpoint _bus;
    public KafkaEventPublisher(IBus bus)
    {
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
    }
    public Task Publish<T>(T @event) where T : IDomainEvent
    {
        return _bus.Publish(@event);
    }
}
