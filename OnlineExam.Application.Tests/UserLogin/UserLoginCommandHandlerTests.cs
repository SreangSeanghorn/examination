using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Moq;
using OnlineExam.Application.Authentication.UserLogin;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Repositories;
using OnlineExam.Domain.Services;
using OnlineExam.Domain.Values;
using OnlineExam.Infrastructure;

namespace OnlineExam.Application.Tests.UserLogin
{
    public class UserLoginCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IPasswordHasher<User>> _passwordHasherMock;
        private readonly Mock<IJwtTokenGenerator> _tokenServiceMock;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserLoginCommandHandler _handler;

        public UserLoginCommandHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _passwordHasherMock = new Mock<IPasswordHasher<User>>();
            _tokenServiceMock = new Mock<IJwtTokenGenerator>();
            _userServiceMock = new Mock<IUserService>();
            _handler = new UserLoginCommandHandler(_userRepositoryMock.Object, _passwordHasherMock.Object, _tokenServiceMock.Object, _userServiceMock.Object);
        }


        [Fact]
        public async Task Handle_WhenUserNotFound_ShouldReturnInvalidResponse()
        {
            // Arrange
            var command = new UserLoginCommand("invalid@example.com", "invalidPassword");

            // Mock the userService to return null (user not found)
            _userServiceMock.Setup(x => x.LoginUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((User)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess); 
            Assert.Equal("Invalid email or password", result.Message); 
            Assert.Null(result.Data);
        }

        // Test case: Successful login

        [Fact]
        public async Task Handle_ValidUser_ShouldReturnValidResponse()
        {
            // Arrange
            var user = User.CreateUser("test", 
            new Email(""),"");
           
            user.AssignRole(Role.Defaults);

            var token = "token";

            var command = new UserLoginCommand("test@gmail.com", "testPassword");
            _userServiceMock.Setup(x => x.LoginUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(user);
            
            _tokenServiceMock.Setup(x => x.GenerateToken(It.IsAny<Guid>(), It.IsAny<string>())).Returns(token);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Login successful", result.Message);
            Assert.NotNull(result.Data);
            Assert.Contains(Role.Defaults.Name, result.Data.Roles);



        }


    }
}