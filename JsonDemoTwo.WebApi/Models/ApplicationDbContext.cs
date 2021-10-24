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

            /*Fluent API*/
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(55);

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

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = 1,
                    Title = "Down the memory lane",
                    UserId = 1,
                }
            );

            modelBuilder.Entity<Photo>().HasData(
                new Photo
                {
                    Id = 1,
                    Title = "At the beach",
                    Url = "https://www.ruben.com",
                    ThumbnailUrl = "http://via.placeholder.com/49",
                    AlbumId = 1,
                }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Twin Cities",
                    Body = "A tale of two cities",
                    UserId = 1,
                }
            );
            

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Name = "Id labore ex et",
                    Email = "ruben@yahoo.com",
                    Body = "To be or not to be",
                    PostId = 1,
                }
            );

           

        base.OnModelCreating(modelBuilder);

        }
    }
}