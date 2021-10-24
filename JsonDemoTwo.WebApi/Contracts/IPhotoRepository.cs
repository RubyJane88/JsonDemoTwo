using System.Collections.Generic;
using System.Threading.Tasks;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;

namespace JsonDemoTwo.Contracts
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<PhotoDto>> GetAllAsync();
        
        Task<PhotoDto> GetByIdAsync(int id);
        Task<PhotoDto> CreateAsync(Photo photo);
        Task DeleteAsync(int id);
        Task<PhotoDto> UpdateAsync(Photo photo);
        Task<bool> ExistsAsync(int id);
    }
}