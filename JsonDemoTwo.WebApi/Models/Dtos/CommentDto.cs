using System.ComponentModel.DataAnnotations;

namespace JsonDemoTwo.Models.Dtos
{
    public sealed class CommentDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(500)]
        public string Body { get; set; }
    }
}