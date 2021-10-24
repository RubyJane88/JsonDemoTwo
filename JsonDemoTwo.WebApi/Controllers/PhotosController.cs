using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JsonDemoTwo.Controllers
{
    [Route("/")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoRepository _repo;

        public PhotosController(IPhotoRepository  repo)
        {
            _repo = repo;
        }
        
        //GET: photos
        [HttpGet("photos")]
        public async Task<IActionResult> GetAllPhotos(string search) // <string search?> model binding 
        {
            try
            {
                var photos = await _repo.GetAllAsync();
                var response = Ok(photos);

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting all the photos");
            }
            
            
        }
        
        
        //GET: photos/{2}

        [HttpGet("photos/{id}")]
        public async Task<IActionResult> GetPhotoById(int id)
        {
            var photo = await _repo.GetByIdAsync(id);
            if (photo == null) 
                return NotFound();

            var reponse = Ok(photo);
            return reponse;
        }
        
       
        //DELETE: /photos/{id}
        [HttpDelete("photos/{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
        
        //POST: photos/{id}
        [Route("photos/{id}")]
        [HttpPost]
        public async Task<IActionResult> PostPhoto(Photo photo)
        {
            var photoDto = await _repo.CreateAsync(photo);
            var response = Ok(photoDto);

            return response;
        }










    }
}