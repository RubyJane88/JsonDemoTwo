using System;
using JsonDemoTwo.Models.Entities;

namespace JsonDemoTwo.Models.Dtos
{
    public sealed class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

         public Address Address { get; set; }
         public Geo Geo { get; set; }
         public Company Company { get; set; }

        public string Phone { get; set; }
        public string Website { get; set; }
        
        
    }
}