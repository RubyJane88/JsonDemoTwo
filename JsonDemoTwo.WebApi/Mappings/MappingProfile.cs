using AutoMapper;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;

namespace JsonDemoTwo.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Album, AlbumDto>().ReverseMap();
            CreateMap<Photo, PhotoDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Todo, TodoDto>().ReverseMap();
        }
    }
}