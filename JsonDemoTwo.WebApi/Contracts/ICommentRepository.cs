using System.Collections.Generic;
using System.Threading.Tasks;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;

namespace JsonDemoTwo.Contracts
{
    public interface ICommentRepository
    {
        Task<IEnumerable<CommentDto>> GetAllAsync();
        Task<CommentDto> GetByIdAsync(int id);
        Task<CommentDto> CreateAsync(Comment comment);
        Task DeleteAsync(int id);
        Task<CommentDto> UpdateAsync(Comment comment);
        Task<bool> ExistsAsync(int id); 
    }
}