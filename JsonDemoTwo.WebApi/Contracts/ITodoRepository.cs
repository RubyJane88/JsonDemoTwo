using System.Collections.Generic;
using System.Threading.Tasks;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;

namespace JsonDemoTwo.Contracts
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoDto>> GetAllAsync();
        Task<TodoDto> GetByIdAsync(int id);
        Task<TodoDto> CreateAsync(Todo todo);
        Task DeleteAsync(int id);
        Task<TodoDto> UpdateAsync(Todo todo);
        Task<bool> ExistsAsync(int id); 
    }
}