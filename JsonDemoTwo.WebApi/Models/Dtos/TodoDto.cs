using System.ComponentModel.DataAnnotations;

namespace JsonDemoTwo.Models.Dtos
{
    public sealed class TodoDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [MinLength(2)]
        [MaxLength(55)]
        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}