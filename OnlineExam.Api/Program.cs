using System.Buffers;
using System.Reflection.Emit;
using OnlineExam.Application;
using OnlineExam.Infrastructure;
using Microsoft.AspNetCore.Builder;
using OnlineExam.Application.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OnlineExam.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Infrastructure.Persistence.DBContext;
using System.Reflection;
using OnlineExam.Application.CommandHandler.Authentication;
using OnlineExam.Domain.Interfaces;
using OnlineExam.Infrastructure.MessageBroker;
using MassTransit.KafkaIntegration;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    // .AddKafkaProducer(builder.Configuration)
    .AddKafkaMassProducer(builder.Configuration);
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("OnlineExam.Infrastructure")));


    builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UserRegisterCommandHandler).GetTypeInfo().Assembly));
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHanldingMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}



