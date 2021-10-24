using System;
using System.Threading.Tasks;
using AutoMapper;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Models;
using JsonDemoTwo.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JsonDemoTwo.Controllers
{
    [Route("/")]
    [ApiController]
    public class UsersController :  ControllerBase
    {
        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }
        
        //GET: users
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetAllAsync();
            var response = Ok(users);

            return response;
        }
        
        //GET: users/id
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repo.GetByIdAsync(id);

            if (user == null)
                return NotFound();
            var response = Ok(user);
            return response;
        }
        
        //DELETE: users/id
        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
        
        //POST: users
        [HttpPost("users")]
        public async Task<IActionResult> PostUser(User user)
        {
            var userDto = await _repo.CreateAsync(user);
            var response = Ok(userDto);

            return response;
        }
        
        

    }
}