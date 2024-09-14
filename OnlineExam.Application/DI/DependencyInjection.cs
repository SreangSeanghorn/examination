using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using OnlineExam.Application.Commands.Authentication;
using OnlineExam.Application.Commands;
using OnlineExam.Application.DTO.Authentication;

using OnlineExam.Domain.Repositories;

using MediatR;

using OnlineExam.Infrastructure.Authentication;
using OnlineExam.Infrastructure.Persistence;
using OnlineExam.Application.CommandHandler.Authentication;
using OnlineExam.Infrastructure.Services;
using OnlineExam.Application.CommandHandler;
using OnlineExam.Infrastructure.Resolver;
using OnlineExam.Infrastructure;
using OnlineExam.Domain.Entities;
using OnlineExam.Infrastructure.Persistence.Repositories;
using OnlineExam.Application.QueriesHandler;
using OnlineExam.Domain.Services;
using OnlineExam.Application.Authentication.UserLogin;
using OnlineExam.Application.Common;
using OnlineExam.Application.Authentication.Services;

namespace OnlineExam.Application{

public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationServiceImp>();
            services.AddScoped<ICommandResolver, CommandResolver>();
            services.AddScoped<IQueryResolver, QueryResolver>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserRegisterCommandHandler).Assembly));
            services.AddScoped<ICommandHandler<UserRegisterCommand, AuthenticationResultResponse>, UserRegisterCommandHandler>();
            services.AddScoped<ICommandHandler<UserLoginCommand, BaseResponse<UserLoginResponse>>, UserLoginCommandHandler>();
            services.AddScoped<IRoleRepository, RoleRepositoy>();
            services.AddScoped<IQueryHandler<GetUserByEmailQuery,GetUserInfoByEmailResponseDTO>, GetUserByEmailQueryHandler>();

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}

    


