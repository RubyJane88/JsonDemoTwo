using System.Threading.Tasks;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JsonDemoTwo.Controllers
{
    [Route("/")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _repo;

        public PostsController(IPostRepository repo)
        {
            _repo = repo;
        }
        
        //GET: posts
        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _repo.GetAllAsync();
            var response = Ok(posts);

            return response;
        }
        
        //GET: posts/{id}
        [HttpGet("posts/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _repo.GetByIdAsync(id);

            if (post == null) return NotFound();

            var response = Ok(post);
            return response;
        }
        
        //DELETE: posts/{id}
        [HttpDelete("posts/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
        
        //POST: post
        [HttpPost("posts")]
        public async Task<IActionResult> PostPost(Post post)
        {
            var postDto = await _repo.CreateAsync(post);
            var response = Ok(postDto);

            return response;

        }

    }
}