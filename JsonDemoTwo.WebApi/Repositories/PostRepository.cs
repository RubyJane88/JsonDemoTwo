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
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        
        
        public async Task<IEnumerable<PostDto>> GetAllAsync()
        {
            try
            {
                var posts = await _context.Posts.ToListAsync();
                var postDto = _mapper.Map<IEnumerable<PostDto>>(posts);

                return postDto;
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting list of posts");
            }
        }

        public async Task<PostDto> GetByIdAsync(int id)
        {
            try
            {
                var post = await _context.Posts.FindAsync(id);
                var postDto = _mapper.Map<PostDto>(post);

                return postDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting post with that id");
            }
        }

        public async Task<PostDto> CreateAsync(Post post)
        {
            try
            {
                await _context.SaveChangesAsync();
                var postDto = _mapper.Map<PostDto>(post);

                return postDto;
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error creating new post");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var exists = await ExistsAsync(id);
                if (!exists) throw new Exception("Not found");

                _context.Remove(await _context.Posts.FindAsync(id));
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error deleting post");
            }
        }

        public async Task<PostDto> UpdateAsync(Post post)
        {
            try
            {
                var exists = await ExistsAsync(post.Id);
                if (!exists) throw new Exception("Not found");

                _context.Update(post);
                await _context.SaveChangesAsync();

                var postDto = _mapper.Map<PostDto>(post);
                return postDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error updating the post");
            }
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Posts.AnyAsync(p => p.Id == id);

    }
}