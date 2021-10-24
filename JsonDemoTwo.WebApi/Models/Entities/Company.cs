using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonDemoTwo.Models.Entities
{
  
    public sealed class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }  
    }
}