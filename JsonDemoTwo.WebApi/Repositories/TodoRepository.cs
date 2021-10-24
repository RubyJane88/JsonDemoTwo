using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Models;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JsonDemoTwo.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TodoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<TodoDto>> GetAllAsync()
        {
            try
            {
                var todos = await _context.Todos.ToListAsync();
                var todoDtos = _mapper.Map<IEnumerable<TodoDto>>(todos);

                return todoDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting the todo list");
            }
        }

        public async Task<TodoDto> GetByIdAsync(int id)
        {
            try
            {
                var todo = await _context.Todos.FindAsync(id);
                var todoDto = _mapper.Map<TodoDto>(todo);
                return todoDto;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting todo with that id");
            }
        }

        public async Task<TodoDto> CreateAsync(Todo todo)
        {
            try
            {
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();

                var todoDto = _mapper.Map<TodoDto>(todo);
                return todoDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error adding new todo");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var exists = await ExistsAsync(id);
                
                if (!exists) throw new Exception("Not found");

                _context.Remove(await _context.Todos.FindAsync(id));
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error deleting todo");
            }
        }

        public async Task<TodoDto> UpdateAsync(Todo todo)
        {
            try
            {
                var exists = await ExistsAsync(todo.Id);

                if (!exists) throw new Exception("Not found");

                _context.Update(todo);
                await _context.SaveChangesAsync();
                var todoDto = _mapper.Map<TodoDto>(todo);
                return todoDto;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error updating todo");
            }
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Todos.AnyAsync(t => t.Id == id);

    }
}