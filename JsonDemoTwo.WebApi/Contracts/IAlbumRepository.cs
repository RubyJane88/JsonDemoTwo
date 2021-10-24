using System.Collections.Generic;
using System.Threading.Tasks;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;

namespace JsonDemoTwo.Contracts
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<AlbumDto>> GetAllAsync();
        Task<AlbumDto> GetByIdAsync(int id);
        Task<AlbumDto> CreateAsync(Album album);
        Task DeleteAsync(int id);
        Task<AlbumDto> UpdateAsync(Album album);
        Task<bool> ExistsAsync(int id); 
    }
}