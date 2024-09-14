using System;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Entities.Users;
using OnlineExam.Domain.Interfaces;
using OnlineExam.Domain.Repositories;
using OnlineExam.Domain.Services;
using OnlineExam.Domain.Values;

namespace OnlineExam.Application.Authentication.Services;


public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IEventPublisher _eventPublisher;
    private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

    public UserService(IUserRepository userRepository, IRoleRepository roleRepository
    , IEventPublisher eventPublisher
    , IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _eventPublisher = eventPublisher;
        _passwordHasher = passwordHasher;
    }

    public Task AssignRoleAsync(Guid userId, Role role)
    {
        var user = _userRepository.GetByIdAsync(userId).Result;
        user.AssignRole(role);
        return _userRepository.SaveChangesAsync();
    }

    public Task<User> GetUserByEmailAsync(string email)
    {
        return _userRepository.GetUserByEmailAsync(email);
    }

    public async Task<User> LoginUserAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailWithRolesAsync(email);
        if (user == null)
        {
            return null; 
        }
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            return null; 
        }
        return user;
    }

    public async Task<User> RegisterUserAsync(string name, string email, string password)
    {
        var mail = new Email(email);
        var user  = User.CreateUser(name, mail, password);
        var defaultRole = await _roleRepository.GetRoleByNameAsync("Default");
        if (defaultRole == null)
        {
            throw new Exception("Default role not found.");
        }
        user.AssignRole(defaultRole);
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();
        var userRegisteredEventData = new UserRegisteredEventData(user.Id, user.Email.Value, user.Username);
        var serializedEvent = JsonConvert.SerializeObject(userRegisteredEventData);
        Console.WriteLine(serializedEvent);
        await _eventPublisher.Publish(new UserRegisteredEvent(user.Id, userRegisteredEventData));
        return user;
    }
   
}
