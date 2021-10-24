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
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AlbumRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
        public async Task<IEnumerable<AlbumDto>> GetAllAsync()
        {
            try
            {
                var albums = await _context.Albums.ToListAsync();
                var albumDto = _mapper.Map<IEnumerable<AlbumDto>>(albums);

                return albumDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting all the albums");
            }
        }

        public async Task<AlbumDto> GetByIdAsync(int id)
        {
            try
            {
                var album = await _context.Albums.FindAsync(id);
                var albumDto = _mapper.Map<AlbumDto>(album);

                return albumDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error getting album with that id");
            }
            
        }

        public async Task<AlbumDto> CreateAsync(Album album)
        {
            try
            {
                _context.Albums.Add(album);
                await _context.SaveChangesAsync();

                var albumDto = _mapper.Map<AlbumDto>(album);
                return albumDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error creating new  album");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var exists = await ExistsAsync(id);
                if (!exists) throw new Exception("Not found");

                _context.Remove(await _context.Albums.FindAsync(id));
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error deleting the album");
            }
        }

        public async Task<AlbumDto> UpdateAsync(Album album)
        {
            try
            {
                var exists = await ExistsAsync(album.Id);
                if (!exists) throw new Exception("Not found");

                _context.Update(album);
                await _context.SaveChangesAsync();
                var albumDto = _mapper.Map<AlbumDto>(album);
                return albumDto;
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Error updating album");
            }
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Albums.AnyAsync(a => a.Id == id);

    }
}