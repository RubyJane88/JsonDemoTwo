using System.Collections.Generic;
using System.Threading.Tasks;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;

namespace JsonDemoTwo.Contracts
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostDto>> GetAllAsync();
        Task<PostDto> GetByIdAsync(int id);
        Task<PostDto> CreateAsync(Post post);
        Task DeleteAsync(int id);
        Task<PostDto> UpdateAsync(Post post);
        Task<bool> ExistsAsync(int id);
    }
}