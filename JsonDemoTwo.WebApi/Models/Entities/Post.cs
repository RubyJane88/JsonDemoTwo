using System.ComponentModel.DataAnnotations;

namespace JsonDemoTwo.Models.Entities
{
    public sealed class Post
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3)]
        [MaxLength(55)]
        public string Title { get; set; }
        
        [MinLength(3)]
        [MaxLength(255)]
        public string Body { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}