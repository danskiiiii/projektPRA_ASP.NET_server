namespace PRAserver.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PRAserver.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<PRAserver.Models.PRAserverContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PRAserver.Models.PRAserverContext context)
        {
            context.Studios.AddOrUpdate(x => x.StudioId,
                new Studio() { StudioId = 1, Name = "Sony", YearOfEstablishment = 1924 },
                new Studio() { StudioId = 2, Name = "Paramount", YearOfEstablishment = 1912 },
                new Studio() { StudioId = 3, Name = "Warner Bros", YearOfEstablishment = 1923 },
                new Studio() { StudioId = 4, Name = "Disney", YearOfEstablishment = 1923 },
                new Studio() { StudioId = 5, Name = "Universal", YearOfEstablishment = 1912 },
                new Studio() { StudioId = 6, Name = "20th Century Fox", YearOfEstablishment = 1935 }
                );

            context.Positions.AddOrUpdate(x => x.PositionId,
                new Position() { PositionId = 1, PositionName = "Director" },
                new Position() { PositionId = 2, PositionName = "Producer" },
                new Position() { PositionId = 3, PositionName = "Actor" },
                new Position() { PositionId = 4, PositionName = "Camera operator" },
                new Position() { PositionId = 5, PositionName = "Art director" },
                new Position() { PositionId = 6, PositionName = "Compositor" }
                );


            context.FilmCrews.AddOrUpdate(x => x.CrewMemberId,
               new FilmCrew() { CrewMemberId = 1, Name = "DiCaprio", Firstname = "Leonardo", Age = 40, PositionId = 3 },
               new FilmCrew() { CrewMemberId = 2, Name = "Hardy", Firstname = "Tom", Age = 38, PositionId = 3 },
               new FilmCrew() { CrewMemberId = 3, Name = "Page", Firstname = "Ellen", Age = 27, PositionId = 3 }, 
               new FilmCrew() { CrewMemberId = 4, Name = "Nolan", Firstname = "Christopher", Age = 50, PositionId = 1 },
               new FilmCrew() { CrewMemberId = 5, Name = "Inarritu", Firstname = "Alejandro", Age = 51, PositionId = 1 },
               new FilmCrew() { CrewMemberId = 6, Name = "Allen", Firstname = "Woody", Age = 77, PositionId = 1 }
               );

            context.Movies.AddOrUpdate(x => x.MovieId,
               new Movie() { MovieId = 1, Title = "Inception",  ProductionYear =2010,   Budget=160, Genre= "Sci-Fi",  StudioId=3 },
               new Movie() { MovieId = 2, Title = "The Revenant", ProductionYear =2015,Budget=135, Genre= "Western",  StudioId=6 },
               new Movie() { MovieId = 3, Title = "Titanic",  ProductionYear =1997,Budget=200, Genre= "Drama",  StudioId=2 },
               new Movie() { MovieId = 4, Title = "Midnight in Paris",  ProductionYear =2011,Budget=17, Genre= "Romantic Comedy",  StudioId=1 },
               new Movie() { MovieId = 5, Title = "Dunkirk",  ProductionYear =2017,Budget=100, Genre= "War Drama",  StudioId=3 },
               new Movie() { MovieId = 6, Title = "Shutter Island",  ProductionYear =2010,Budget=80, Genre = "Thriller", StudioId=2 },
               new Movie() { MovieId = 7, Title = "Birdman", ProductionYear = 2014, Budget = 18, Genre = "Comedy", StudioId = 6 }
               );


            context.Contracts.AddOrUpdate(x => x.ContractId,
                new Contract() { ContractId = 1, Duration =45 , Salary = 5000000, CrewMemberId =1 , MovieId = 1    },
                new Contract() { ContractId = 2, Duration =25 , Salary = 1000000, CrewMemberId = 2, MovieId = 1   },
                new Contract() { ContractId = 3, Duration =210 , Salary = 15000000, CrewMemberId =4 , MovieId = 1    },
                new Contract() { ContractId = 4, Duration =50 , Salary = 2000000, CrewMemberId =1 , MovieId = 2    },
                new Contract() { ContractId = 5, Duration =50 , Salary = 1500000, CrewMemberId =2 , MovieId = 2    },
                new Contract() { ContractId = 6, Duration =60 , Salary = 500000, CrewMemberId = 1, MovieId = 3    },
                new Contract() { ContractId = 7, Duration =150 , Salary = 1500000, CrewMemberId = 6, MovieId = 4    },
                new Contract() { ContractId = 8, Duration =320 , Salary = 9000000, CrewMemberId =4 , MovieId = 5     },
                new Contract() { ContractId = 9, Duration =12 , Salary = 450000, CrewMemberId =2 , MovieId = 5     },
                new Contract() { ContractId = 10, Duration =70 , Salary = 700000, CrewMemberId=1 , MovieId = 6     }
                );                                               


        }
    }
}
