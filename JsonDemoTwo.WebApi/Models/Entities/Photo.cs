using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonDemoTwo.Models.Entities
{
   
    public sealed class Photo
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Url  is required")]
        [Url]
        public string Url { get; set; }
        
        public string ThumbnailUrl { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}