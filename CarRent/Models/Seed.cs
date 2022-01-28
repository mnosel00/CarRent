using Microsoft.EntityFrameworkCore;

namespace CarRent.Models
{
    public static class Seed
    {
        public static void CompanySeed(this ModelBuilder builder)
        {
            builder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "SAIC Motor"
                },
                 new Company
                 {
                     Id = 2,
                     Name = "BMW Group"
                 },
                  new Company
                  {
                      Id = 3,
                      Name = "Honda Motor"
                  },
                   new Company
                   {
                       Id = 4,
                       Name = "Generals Motors"
                   },
                    new Company
                    {
                        Id = 5,
                        Name = "Ford Motor"
                    },
                     new Company
                     {
                         Id = 6,
                         Name = "Daimler"
                     },
                      new Company
                      {
                          Id = 7,
                          Name = "Volkswagen Group"
                      },
                       new Company
                       {
                           Id = 8,
                           Name = "Toyota Motor"
                       },
                        new Company
                        {
                            Id = 9,
                            Name = "Stellantis"
                        },
                         new Company
                         {
                             Id = 10,
                             Name = "Hyundai Motor"
                         }

                );
        }
        public static void TypSeed(this ModelBuilder builder)
        {
            builder.Entity<Typ>().HasData(
                new Typ
                {
                    Id = 1,
                    Undercarriage = "Sedan"
                },
                new Typ
                {
                    Id = 2,
                    Undercarriage = "SUV"
                },
                new Typ
                {
                    Id = 3,
                    Undercarriage = "Lift-back"
                },
                new Typ
                {
                    Id = 4,
                    Undercarriage = "Hatch-back"
                },
                new Typ
                {
                    Id = 5,
                    Undercarriage = "Combi"
                },
                new Typ
                {
                    Id = 6,
                    Undercarriage = "Pick-Up"
                },
                new Typ
                {
                    Id = 7,
                    Undercarriage = "Cabriolet"
                },
                new Typ
                {
                    Id = 8,
                    Undercarriage = "Minivan"
                },
                new Typ
                {
                    Id = 9,
                    Undercarriage = "Sport"
                },
                 new Typ
                 {
                     Id = 10,
                     Undercarriage = "Electric"
                 }


                );
        }
    }
}
