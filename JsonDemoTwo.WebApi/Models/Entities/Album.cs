using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonDemoTwo.Models.Entities
{
    
    public sealed class Album
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public int? UserId { get; set; }
         public User User { get; set; }

        
    }
}