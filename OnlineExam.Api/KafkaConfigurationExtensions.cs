using Microsoft.EntityFrameworkCore;
using MassTransit;
using MassTransit.KafkaIntegration;
using OnlineExam.Domain.Entities.Users;
using OnlineExam.Application.Authentication.UserRegister;
using OnlineExam.Domain.Interfaces;
using OnlineExam.Infrastructure.MessageBroker;

public static class KafkaConfigurationExtensions
{
    public static IServiceCollection AddKafkaMassProducer(this IServiceCollection services, IConfiguration configuration)
    {
        var brokerAddress = configuration["Kafka:BrokerAddress"];
        var topicName = configuration["Kafka:TopicName"];

        services.AddMassTransit(mt =>
        {
            // Register the consumer
            mt.AddConsumer<UserRegisteredEventConsumer>();  // Ensure this is registered

            mt.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });

            mt.AddRider(rider =>
            {
                rider.AddConsumer<UserRegisteredEventConsumer>();  // Register consumer here as well

                rider.UsingKafka((context, k) =>
                {
                    k.Host(brokerAddress); // Use the configuration value for broker address

                    // Define the topic and consumer group
                    k.TopicEndpoint<UserRegisteredEvent>(topicName, "user", e =>
                    {
                        e.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
                        e.ConfigureConsumer<UserRegisteredEventConsumer>(context); // Configure the consumer
                    });
                });
            });
        });

        services.AddMassTransitHostedService(true); // Ensure the hosted service is started with the application
        services.AddScoped<IEventPublisher, KafkaEventPublisher>(); // Register the producer
        return services;
    }


}



