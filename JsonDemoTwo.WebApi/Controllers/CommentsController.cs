using System;
using System.Threading.Tasks;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JsonDemoTwo.Controllers
{
    [Route("/")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _repo;

        public CommentsController(ICommentRepository repo)
        {
            _repo = repo;
        }
        
        //GET: comments
        [HttpGet("comments")]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _repo.GetAllAsync();
            var response = Ok(comments);
            return response;
        }
        
        //GET: comments/{id}
        [HttpGet("comments/{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _repo.GetByIdAsync(id);

            if (comment == null) throw new Exception("Not found");

            var response = Ok(comment);
            return response;

        }
        
        //DELETE: comments/{id}
        [HttpDelete("comments/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();

        }
        
        //POST: comments
        [HttpPost("comments/{id}")]
        public async Task<IActionResult> PostComment(Comment comment)
        {
            var commentDto = await _repo.CreateAsync(comment);
            var response = Ok(commentDto);
            return response;
        }
        
        //PUT: comments/{id}
        [HttpPut("comments/{id}")]
        public async Task<IActionResult> PutTodo(int id, Comment comment)
        {
            if (id != comment.Id) return BadRequest();

            await _repo.UpdateAsync(comment);
            return NoContent();
        }
    }
}