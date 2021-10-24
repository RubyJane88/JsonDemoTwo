using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonDemoTwo.Models.Entities
{
    [Table("User")]
    public sealed class User
    {
        public int Id { get; set; }
        
        [MinLength(3)]
        public string Name { get; set; }

     
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int GeoId { get; set; }
        public Geo Geo { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

   
    }
}