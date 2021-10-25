using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Controllers;
using JsonDemoTwo.Data;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Unit.Tests.Controllers
{
    public class UsersControllerTest
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly UsersController _controller;

        public UsersControllerTest()
        {
            _mockRepo = new Mock<IUserRepository>();
            _controller = new UsersController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetUsersTest()
        {
            //arrange 
            var mockUsersDtos = UserMockData.GetAllUsers();
            _mockRepo.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(mockUsersDtos));
            
            //act
            var result = await _controller.GetUsers();
            var response = (OkObjectResult)result;
            var users = (IEnumerable<UserDto>)response.Value;
            
            //assert
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.NotNull(users);
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(4, users.Count());
            
            //Fluent Assertions version
            result.Should().BeAssignableTo<ActionResult>();
            users.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            users.Count().Should().Be(4);
        }

        [Theory]
        [InlineData(2,6)]
        public async Task GetUserByIdTest(int validId,  int invalidId) 
        {
            //arrange 
            var validItemId = validId;
            var mockUserDto = UserMockData.GetAllUsers().First(t => t.Id == validItemId);
            _mockRepo.Setup(repository => repository.GetByIdAsync(validItemId)).Returns(Task.FromResult(mockUserDto));
            
            //act
            var result = await _controller.GetUserById(validId);
            var response = (OkObjectResult)result;
            var user = (UserDto)response.Value;
            
            //assert
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(user);
            
            //Fluent Assertions versions
            result.Should().BeAssignableTo<IActionResult>();
            response.StatusCode.Should().Be(200);
            user.Should().NotBeNull();
            
            //arrange
            var invalidItemId = invalidId;
            var mockInvalidUserDto = UserMockData.GetAllUsers().FirstOrDefault(u => u.Id == invalidId);
            
            _mockRepo.Setup(repository => repository
                    .GetByIdAsync(invalidItemId))
                .Returns(Task.FromResult(mockInvalidUserDto));
                
            //act
            var invalidResult = await _controller.GetUserById(invalidId);
            var notFoundResponse = (NotFoundResult)invalidResult;

            //assert
            Assert.Equal(404, notFoundResponse.StatusCode);
            
            /* Fluent Assertions version */
            notFoundResponse.StatusCode.Should().Be(404);
            
        }
        
        [Theory]
        [InlineData(1)]
        public async Task DeleteUserTest(int validId)
        {
            //arrange
            var mockUsersDtos = UserMockData.GetAllUsers();
            _mockRepo.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(mockUsersDtos));
            var validUserId = validId;
            
            //act
            var result = await _controller.DeleteUser(validUserId);
            var response = (NoContentResult)result;
            
            //assert 
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(204, response.StatusCode);
            
            //Fluent Assertions version
            result.Should().BeAssignableTo<IActionResult>();
            response.StatusCode.Should().Be(204);

        }
        
        [Fact]
        public async Task PostUserTest()
        {
            //arrange
            var mockUserDto = UserMockData.GetOneUserDto();
            var newUser = new User
            {
                Id = 4,
                Name = "Eren Zeynalov",
                UserName = "Eren",
                Email = "eren@gmail.com",
                Address = new Address
                {
                    Id = 4,
                    Street = "Broadway",
                    Suite = "Apartment 234",
                    City = "Albuquerque City",
                    ZipCode = "1234",
                },
                Geo = new Geo
                {
                    Id = 4,
                    Lat = 123445,
                    Lng = 45343,
                },
                Company = new Company
                {
                    Id = 4,
                    Name = "Piano Bootcamp",
                    Bs = "The Thing",
                    CatchPhrase = "Whatever happens",
                },
                Phone = "89122852",
                Website = "www.eren.com",
                
            };

            _mockRepo.Setup(repository => repository
                .CreateAsync(newUser)).Returns(Task.FromResult(mockUserDto));
            
            //act
            var result = await _controller.PostUser(newUser);
            var response = (OkObjectResult)result;
            var userDto = (UserDto)response.Value;
            
            //assert
            Assert.NotNull(userDto);
            Assert.IsType<int>(userDto.Id);
            Assert.Equal(200, response.StatusCode);
            
            //Fluent assertions versions
            userDto.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        
        
        
    }
}