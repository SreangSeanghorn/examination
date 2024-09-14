using System;
using Microsoft.AspNetCore.Identity;
using Moq;
using OnlineExam.Application.Authentication.Services;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Interfaces;
using OnlineExam.Domain.Repositories;
using OnlineExam.Domain.Values;

namespace OnlineExam.Application.Tests.UserServices;

public class UserServiceTests
{

    private readonly Mock<IUserRepository> _userRepository;
    private readonly Mock<IRoleRepository> _roleRepository;
    private readonly Mock<IEventPublisher> _eventPublisher;
    private readonly Mock<IPasswordHasher<User>> _passwordHasher;
   private readonly UserService userService;
    
        public UserServiceTests()
        {
            _userRepository = new Mock<IUserRepository>();
            _roleRepository = new Mock<IRoleRepository>();
            _eventPublisher = new Mock<IEventPublisher>();
            _passwordHasher = new Mock<IPasswordHasher<User>>();
            userService = new UserService(_userRepository.Object, _roleRepository.Object, _eventPublisher.Object, _passwordHasher.Object);
        }

    // User RegisterUser Success
    [Fact]
    public async Task RegisterUserAsync_WhenDefaultRoleNotFound_ShouldThrowException()
    {
        // Arrange
        var userName = "testuser";
        var email = "test@example.com";
        var password = "testpassword";

        _roleRepository.Setup(x => x.GetRoleByNameAsync("Default"))
            .ReturnsAsync((Role)null);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() =>
            userService.RegisterUserAsync(userName, email, password));
    }

    // User Login with correct credentials
    [Fact]
    public async Task LoginUserAsync_WithValidCredentials_ShouldReturnUser()
    {
        // Arrange
        var email = new Email("test@gmail.com");
        var password = "testpassword";
        var role = new Role("Admin");

        var user = new User(Guid.NewGuid(),"testuser",email , password);
        user.AssignRole(role);
        _userRepository.Setup(x => x.GetUserByEmailWithRolesAsync(email.Value))
            .ReturnsAsync(user);
        _passwordHasher.Setup(x => x.VerifyHashedPassword(user, user.Password, password))
            .Returns(PasswordVerificationResult.Success);
        
        // Act

        var result = await userService.LoginUserAsync(email.Value, password);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(user, result);
        _userRepository.Verify(x => x.GetUserByEmailWithRolesAsync(email.Value), Times.Once);

    }





}
