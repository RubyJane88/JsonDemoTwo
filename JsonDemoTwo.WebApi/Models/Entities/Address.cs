using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonDemoTwo.Models.Entities
{
   
    public sealed class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}