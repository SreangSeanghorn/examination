using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Infrastructure.Authentication;
using OnlineExam.Application.Common.Interface.Services;
using OnlineExam.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using OnlineExam.Infrastructure.Persistence;
using OnlineExam.Domain.Repositories;
using OnlineExam.Infrastructure.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Interfaces;
using OnlineExam.Infrastructure.MessageBroker;
using Confluent.Kafka;
using MassTransit;

namespace OnlineExam.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthenticationService, AuthenticationServiceImp>();
        // services.AddSingleton<IEventPublisher, KafkaProducerService>();
        services.AddScoped<IEventPublisher, KafkaEventPublisher>();
        return services;
    }

    public static IServiceCollection AddKafkaProducer(this IServiceCollection services, IConfiguration configuration)
    {
        var brokerAddress = configuration["Kafka:BrokerAddress"];
        var topicName = configuration["Kafka:TopicName"];

        if (string.IsNullOrEmpty(brokerAddress))
            throw new ArgumentNullException(nameof(brokerAddress), "Kafka broker address is not configured.");
        if (string.IsNullOrEmpty(topicName))
            throw new ArgumentNullException(nameof(topicName), "Kafka topic name is not configured.");

        var producerConfig = new ProducerConfig
        {
            BootstrapServers = brokerAddress
        };
        var producer = new ProducerBuilder<string, string>(producerConfig).Build();
        Console.WriteLine("Kafka producer created successfully." + producer.Name);
        services.AddSingleton<IProducer<string, string>>(producer);

        var kafkaProducer = producer;
        Console.WriteLine("Kafka producer created successfully." + kafkaProducer.Name);
        var kafkaProducerService = new KafkaProducerService(kafkaProducer, topicName);
        Console.WriteLine("Kafka producer service created successfully." + kafkaProducerService.ToString());
        services.AddScoped<IEventPublisher>(provider =>
        {       
            return kafkaProducerService;
        });

        return services;
    }

   





}
