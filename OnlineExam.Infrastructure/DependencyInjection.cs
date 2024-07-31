using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Infrastructure.Authentication;
using OnlineExam.Application.Common.Interface.Services;
using OnlineExam.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using OnlineExam.Infrastructure.Persistence;
using OnlineExam.Domain.Repositories;

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
        return services;
    }
}
