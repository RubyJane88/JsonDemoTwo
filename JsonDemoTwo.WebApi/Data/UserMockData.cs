using System.Collections.Generic;
using JsonDemoTwo.Models.Dtos;
using JsonDemoTwo.Models.Entities;

namespace JsonDemoTwo.Data
{
    public static class UserMockData
    {
        public static IEnumerable<UserDto> GetAllUsers()
        {
            var userDtos = new List<UserDto>
            {
                new()
                {
                    Id = 1,
                    Name = "Kairo Juan",
                    UserName = "KJC",
                    Email = "kairo@gmail.com",
                    Address = new Address
                    {
                        Id = 1,
                        Street = "Sitara",
                        Suite = "Mirea",
                        City = "Pasig City",
                        ZipCode = "1234",
                    },
                    Geo = new Geo
                    {
                        Id = 1,
                        Lat = 123445,
                        Lng = 45343,
                    },
                    Company = new Company
                    {
                        Id = 1,
                        Name = "Baby Bootcamp",
                        Bs = "The Thing",
                        CatchPhrase = "Whatever happens",
                    },
                    Phone = "89122453",
                    Website = "www.kairo.com",
                },
                
                new()
                {
                    Id = 2,
                    Name = "Raikko Juan",
                    UserName = "RJC",
                    Email = "raikko@gmail.com",
                    Address = new Address
                    {
                        Id = 2,
                        Street = "Sitara",
                        Suite = "Mirea",
                        City = "Pasig City",
                        ZipCode = "1234",
                    },
                    Geo = new Geo
                    {
                        Id = 2,
                        Lat = 123445,
                        Lng = 45343,
                    },
                    Company = new Company
                    {
                        Id = 2,
                        Name = "Baby Bootcamp",
                        Bs = "The Thing",
                        CatchPhrase = "Whatever happens",
                    },
                    Phone = "89122452",
                    Website = "www.raikko.com",
                },
                
                new()
                {
                    Id = 3,
                    Name = "Mathieu Isaac",
                    UserName = "Mat",
                    Email = "mat@gmail.com",
                    Address = new Address
                    {
                        Id = 3,
                        Street = "Saint Ros Parkway",
                        Suite = "Oculus",
                        City = "New York City",
                        ZipCode = "1234",
                    },
                    Geo = new Geo
                    {
                        Id = 3,
                        Lat = 123445,
                        Lng = 45343,
                    },
                    Company = new Company
                    {
                        Id = 3,
                        Name = "Math Bootcamp",
                        Bs = "The Thing",
                        CatchPhrase = "Whatever happens",
                    },
                    Phone = "89122852",
                    Website = "www.mathieu.com",
                },
                
                new()
                {
                    Id = 4,
                    Name = "Eren Zeynalov",
                    UserName = "Eren",
                    Email = "eren@gmail.com",
                    Address = new Address
                    {
                        Id = 4,
                        Street = "Broadway",
                        Suite = "Apartment 234",
                        City = "Albuquerque City",
                        ZipCode = "1234",
                    },
                    Geo = new Geo
                    {
                        Id = 4,
                        Lat = 123445,
                        Lng = 45343,
                    },
                    Company = new Company
                    {
                        Id = 4,
                        Name = "Piano Bootcamp",
                        Bs = "The Thing",
                        CatchPhrase = "Whatever happens",
                    },
                    Phone = "89122852",
                    Website = "www.eren.com",
                },
                
            };
            return userDtos;
        }

        public static User GetOneUser()
        {
            var user = new User
            {
                Id = 2,
                Name = "Riley Elizabeth",
                UserName = "Riley",
                Email = "riley@gmail.com",
                Address = new Address
                {
                    Id = 2,
                    Street = "Sitara",
                    Suite = "Mirea",
                    City = "Pasig City",
                    ZipCode = "1234",
                },
                Geo = new Geo
                {
                Id = 2,
                Lat = 123445,
                Lng = 45343,
            },
            Company = new Company
            {
                Id = 2,
                Name = "Frozen Camp",
                Bs = "The Thing",
                CatchPhrase = "Whatever happens",
            },
            Phone = "89122455",
            Website = "www.riley.com",

            };
            return user;
        }

        public static UserDto GetOneUserDto()
        {
            var userDto = new UserDto
            {
                Id = 2,
                Name = "Elijah Ruben",
                UserName = "Elijah",
                Email = "elijah@gmail.com",
                Address = new Address
                {
                    Id = 2,
                    Street = "Horseshoe",
                    Suite = "Apartment 1",
                    City = "Las Vegas City",
                    ZipCode = "12332",
                },
                Geo = new Geo
                {
                    Id = 2,
                    Lat = 323445,
                    Lng = 453543,
                },
                Company = new Company
                {
                    Id = 2,
                    Name = "Summer Bootcamp 4",
                    Bs = "The IT",
                    CatchPhrase = "Coding Camp",
                },
                Phone = "89122455",
                Website = "www.elijah.com",
            };

            return userDto;
        }
        
        
        
        

    }
}