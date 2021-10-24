using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Models;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace JsonDemoTwo.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            try
            {
                var comments = await _context.Comments.ToListAsync();
                var commentDtos = _mapper.Map<IEnumerable<CommentDto>>(comments);
                return commentDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting all the comments");
            }
        }

        public async Task<CommentDto> GetByIdAsync(int id)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(id);
                var commentDto = _mapper.Map<CommentDto>(comment);
                return commentDto;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting comment with that id");
            }
        }

        public async Task<CommentDto> CreateAsync(Comment comment)
        {
            try
            {
                _context.Comments.Add(comment);
                
                await _context.SaveChangesAsync();

                var commentDto = _mapper.Map<CommentDto>(comment);
                return commentDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error creating new comment");
                
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var exists = await ExistsAsync(id);
                if (!exists) throw new Exception("Not found");

                _context.Remove(await _context.Comments.FindAsync(id));
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error deleting comment");
            }
        }

        public async Task<CommentDto> UpdateAsync(Comment comment)
        {
            var exists = await ExistsAsync(comment.Id);
            if (!exists) throw new Exception("Not found");

            _context.Update(comment);
            await _context.SaveChangesAsync();
            var commentDto = _mapper.Map<CommentDto>(comment);
            return commentDto;
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Comments.AnyAsync(c => c.Id == id);

    }
}