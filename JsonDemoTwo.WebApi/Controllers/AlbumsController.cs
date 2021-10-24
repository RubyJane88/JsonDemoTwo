using System;
using System.Threading.Tasks;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JsonDemoTwo.Controllers
{
    [Route("/")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepository _repo;

        public AlbumsController(IAlbumRepository repo)
        {
            _repo = repo;
        }
        
        //GET: albums
        [HttpGet("albums")]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await _repo.GetAllAsync();
            var response = Ok(albums);

            return response;
        }
        
        //GET: api/album/id 
        [HttpGet("albums/{id}")]
        public async Task<IActionResult> GetAlbumById(int id)
        {
            var album = await _repo.GetByIdAsync(id);
            if (album == null) return NotFound();

            var response = Ok(album);
            return response;
            
        }
        
        //DELETE: api/album/id
        [HttpDelete("albums/{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
       
        //POST: api/album
        [HttpPost("albums")]
        public async Task<IActionResult> PostAlbum(Album album)
        {
            var albumDto = await _repo.CreateAsync(album);
            var response = Ok(albumDto);

            return response;

        }

    }
}