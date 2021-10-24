using System;
using System.Collections.Generic;
using System.Xml;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;

namespace JsonDemoTwo.Data
{
    public static class MockData
    {
        public static IEnumerable<TodoDto> GetAllTodos()
        {
            var todoDtos = new List<TodoDto>()
            {
                new()
                {
                    Id = 1,
                    Title = "Clean the room",
                    Completed = false
                },

                new()
                {
                    Id = 2,
                    Title = "Wash the dishes",
                    Completed = false
                },

                new()
                {
                    Id = 3,
                    Title = "Buy clothes",
                    Completed = false
                },

                new()
                {
                    Id = 4,
                    Title = "Sleep like a baby",
                    Completed = false
                },
            };

            return todoDtos;

        }

        public static Todo GetOneTodo()
        {
            var todo = new Todo {  
                Id = 1,
                Title = "Debugging",
                Completed = false
            };
            
            return todo;
        }
        
        public static TodoDto GetOneTodoDto()
        {
            var todoDto = new TodoDto
            { 
                Id = 1,
                Title = "Coding",
                Completed = false
            };
            
            return todoDto;
        }

    }
}