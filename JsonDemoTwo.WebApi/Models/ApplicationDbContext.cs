using System.Runtime.Intrinsics;
using JsonDemoTwo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JsonDemoTwo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Todo> Todos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    Street = "123 Adarna Street",
                    Suite = "Apartment 307",
                    City = "Antipolo City",
                    ZipCode = "12345",
                    
                }
            );

            modelBuilder.Entity<Geo>().HasData(
                new Geo
                {
                    Id = 1,
                    Lat = 14-622360,
                    Lng = 121-166153,
                }
            );

            modelBuilder.Entity<Company>().HasData(
             new Company
                 
             {
                 Id = 1,
                 Name = "Dagohoy Services",
                 CatchPhrase = "The guards you can trust",
                 Bs = "harness real-time guards"
             }
            ); 
            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                 Id = 1,
                 Name = "Ruben",
                 UserName = "Bugsy",
                 Email = "ruben@yahoo.com",
                 Phone = "9178482318",
                 Website = "bugsy.com",
                 AddressId = 1,
                 GeoId = 1,
                 CompanyId = 1,
                 
                }
                
            );

            modelBuilder.Entity<Todo>().HasData(

                new Todo
                {
                    Id = 1,
                    Completed = true,
                    Title = "Write Practical React Enterprise",
                    UserId = 1,

                }
            );
               

           

        base.OnModelCreating(modelBuilder);

        }
    }
}