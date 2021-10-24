using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;

namespace JsonDemoTwo.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(User user);
        Task DeleteAsync(int id);
        Task<UserDto> UpdateAsync(User user);
        Task<bool> ExistsAsync(int id);
    }
}