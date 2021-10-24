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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper  mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            try
            {
                var users = await _context
                                    .Users
                                    .Include(u => u.Address)
                                    .Include(u => u.Company) 
                                    .Include(u => u.Geo)
                                    .ToListAsync();
                var userDto = _mapper.Map<IEnumerable<UserDto>>(users);

                return userDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting users list");
            }
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                var userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting user of that id");
            }
        }

        public async Task<UserDto> CreateAsync(User user)
        {
            try
            {
            
                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                var userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error creating new user");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var exists = await ExistsAsync(id);
                if (!exists) throw new Exception("Not found");

                _context.Remove(await _context.Users.FindAsync(id));
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error deleting user");
            }
        }

        public async Task<UserDto> UpdateAsync(User user)
        {
            try
            {
                var exists = await ExistsAsync(user.Id);
                if (!exists) throw new Exception("Not  found");

                _context.Update(user);
                await _context.SaveChangesAsync();
                var userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error updating user");
            }
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Users.AnyAsync(u => u.Id == id);

    }
}