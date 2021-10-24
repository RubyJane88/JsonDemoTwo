using System.Threading.Tasks;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JsonDemoTwo.Controllers
{
    [Route("/")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _repo;

        public TodosController(ITodoRepository repo)
        {
            _repo = repo;
        }
        
        //GET: todos
        [HttpGet("todos")]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _repo.GetAllAsync();
            var response = Ok(todos);

            return response;
        }
        
        //GET: todos/{id}
        [HttpGet("todos/{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var todo = await _repo.GetByIdAsync(id);

            if (todo == null)
                return NotFound();

            var response = Ok(todo);
            return response;
        }
        
        //DELETE: todos/{id}
        [HttpDelete("todos/{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
        
        //POST: todos
        [HttpPost("todos")]
        public async Task<IActionResult> PostTodo(Todo todo)
        {
            var todoDto = await _repo.CreateAsync(todo);
            var response = Ok(todoDto);

            return response;
        }
        
        //PUT: todos/{id}
        [HttpPut("todos/{id}")]
        public async Task<IActionResult> PutTodo(int id, Todo todo)
        {
            if (id != todo.Id) return BadRequest();

            await _repo.UpdateAsync(todo);
            return NoContent();
        }

    }
}