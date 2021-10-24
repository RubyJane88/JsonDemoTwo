using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Models;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace JsonDemoTwo.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PhotoRepository(ApplicationDbContext  context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
        
        public async Task<IEnumerable<PhotoDto>> GetAllAsync()
        {
            try
            {
                var photos = await _context.Photos.ToListAsync();
                var photosDto = _mapper.Map<IEnumerable<PhotoDto>>(photos);

                return photosDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting all the photos");
            }
        }

        public async Task<PhotoDto> GetByIdAsync(int id)
        {
            try
            {
                var photo = await _context.Photos.FindAsync(id);
                var photoDto = _mapper.Map<PhotoDto>(photo);

                return photoDto;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting photo with that id"); 
            }
        }

        public async Task<PhotoDto> CreateAsync(Photo photo)
        {
            try
            {
                await _context.SaveChangesAsync();
                var photoDto = _mapper.Map<PhotoDto>(photo);

                return photoDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error creating new photo");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var exists = await ExistsAsync(id);
                if (!exists) throw new Exception("Not found");

                _context.Remove(await _context.Photos.FindAsync(id));
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error deleting photo");
            }
        }

        public async Task<PhotoDto> UpdateAsync(Photo photo)
        {
            try
            {
                var exists = await ExistsAsync(photo.Id);
                if (!exists) throw new Exception("Not found");

                _context.Update(photo);
                await _context.SaveChangesAsync();
                var photoDto = _mapper.Map<PhotoDto>(photo);
                return photoDto;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error updating photo");
            }
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Photos.AnyAsync(p => p.Id == id);

    }
}