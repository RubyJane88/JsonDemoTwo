using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    public class TodosControllerTest
    {
        private readonly Mock<ITodoRepository> _mockRepo;
        private readonly TodosController _controller;

        public TodosControllerTest()
        {
            _mockRepo = new Mock<ITodoRepository>();
            _controller = new TodosController(_mockRepo.Object);
        }


        [Fact]
        public async Task GetTodosTest()
        {
            //arrange 
            var mockTodosDtos = MockData.GetAllTodos();
            _mockRepo.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(mockTodosDtos));
            
            //act
            var result = await _controller.GetTodos();
            var response = (OkObjectResult)result;
            var todos = (IEnumerable<TodoDto>)response.Value;
            
            //assert 
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.NotNull(todos);
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(4, todos.Count());
            
            //Fluent Assertions version
            result.Should().BeAssignableTo<ActionResult>();
            todos.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            todos.Count().Should().Be(4);

        }

        [Theory]
        [InlineData(1,6)]
        public async Task GetTodoByIdTest(int validId,  int invalidId) 
        {
            //arrange 
            var validItemId = validId;
            var mockTodoDto = MockData.GetAllTodos().First(t => t.Id == validItemId);
            _mockRepo.Setup(repository => repository.GetByIdAsync(validItemId)).Returns(Task.FromResult(mockTodoDto));
            
            //act
            var result = await _controller.GetTodoById(validId);
            var response = (OkObjectResult)result;
            var todo = (TodoDto)response.Value;
            
            //assert
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(todo);
            
            //Fluent Assertions versions
            result.Should().BeAssignableTo<IActionResult>();
            response.StatusCode.Should().Be(200);
            todo.Should().NotBeNull();
            
            //arrange
            var invalidItemId = invalidId;
            var mockInvalidTodoDto = MockData.GetAllTodos().FirstOrDefault(t => t.Id == invalidId);
            
            _mockRepo.Setup(repository => repository
                    .GetByIdAsync(invalidItemId))
                .Returns(Task.FromResult(mockInvalidTodoDto));
                
            //act
            var invalidResult = await _controller.GetTodoById(invalidId);
            var notFoundResponse = (NotFoundResult)invalidResult;

            //assert
            Assert.Equal(404, notFoundResponse.StatusCode);
            
            /* Fluent Assertions version */
            notFoundResponse.StatusCode.Should().Be(404);
            
        }

        [Theory]
        [InlineData(1)]
        public async Task DeleteTodoTest(int validId)
        {
            //arrange
            var mockTodosDtos = MockData.GetAllTodos();
            _mockRepo.Setup(repository => repository.GetAllAsync()).Returns(Task.FromResult(mockTodosDtos));
            var validTodoId = validId;
            
            //act
            var result = await _controller.DeleteTodo(validTodoId);
            var response = (NoContentResult)result;
            
            //assert 
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(204, response.StatusCode);
            
            //Fluent Assertions version
            result.Should().BeAssignableTo<IActionResult>();
            response.StatusCode.Should().Be(204);

        }

        [Fact]
        public async Task PostTodoTest()
        {
            //arrange
            var mockTodoDto = MockData.GetOneTodoDto();
            var newTodo = new Todo
            {
                Title = mockTodoDto.Title,
                Completed = mockTodoDto.Completed
            };

            _mockRepo.Setup(repository => repository
                .CreateAsync(newTodo)).Returns(Task.FromResult(mockTodoDto));
            
            //act
            var result = await _controller.PostTodo(newTodo);
            var response = (OkObjectResult)result;
            var todoDto = (TodoDto)response.Value;
            
            //assert
            Assert.NotNull(todoDto);
            Assert.IsType<int>(todoDto.Id);
            Assert.Equal(200, response.StatusCode);
            
            //Fluent assertions versions
            todoDto.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task PutTodoTest()
        {
            //arrange
            var mockTodo = MockData.GetOneTodo();
            var mockTodoDto = MockData.GetOneTodoDto();
            mockTodo.Completed = true;

            _mockRepo.Setup(repository => repository
                .UpdateAsync(mockTodo))
                .Returns(Task.FromResult(mockTodoDto));
            
            //act
            var result = await _controller.PutTodo(mockTodo.Id, mockTodo);
            var response = (NoContentResult)result;
            
            //assert
            Assert.IsAssignableFrom<IActionResult>(result);
            Assert.Equal(204, response.StatusCode);
            
            //Fluent assertions version
            result.Should().BeAssignableTo<IActionResult>();
            response.StatusCode.Should().Be(204);
        }
        


    }
}