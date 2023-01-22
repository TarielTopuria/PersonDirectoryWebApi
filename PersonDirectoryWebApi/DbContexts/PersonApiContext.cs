using Microsoft.EntityFrameworkCore;
using PersonDirectoryWebApi.Entities;

namespace PersonDirectoryWebApi.DbContexts
{
    public class PersonApiContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<RelatedPerson> RelatedPersons { get; set; }
        public PersonApiContext(DbContextOptions<PersonApiContext> options) : base (options)
        {

        }
        #region DataCreation
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region City Data Builder

            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = 1,
                    Name = "Tbilisi",
                },
                new City()
                {
                    Id = 2,
                    Name = "Batumi"
                },
                new City()
                {
                    Id = 3,
                    Name = "Zugdidi"
                });
            #endregion

            #region Person Data Builder

            modelBuilder.Entity<Person>().HasData(
                new Person()
                {
                    Id = 1,
                    FirstName = "Tato",
                    LastName = "Topuria",
                    GenderId = Enums.GenderTypeEnum.Male,
                    PersonalNumber = "00000000000",
                    DateOfBirth = new DateTime(1997, 5, 29),
                    CityId = 1,
                    ImagePath = "Path to his image"
                },
                new Person()
                {
                    Id = 2,
                    FirstName = "Sophio",
                    LastName = "Khopheria",
                    GenderId = Enums.GenderTypeEnum.Female,
                    PersonalNumber = "00000000000",
                    DateOfBirth = new DateTime(1997, 1, 23),
                    CityId = 1,
                    ImagePath = "Path to her image"
                },
                new Person()
                {
                    Id = 3,
                    FirstName = "Mikheil",
                    LastName = "Topuria",
                    GenderId = Enums.GenderTypeEnum.Male,
                    PersonalNumber = "00000000000",
                    DateOfBirth = new DateTime(1993, 6, 26),
                    CityId = 1,
                    ImagePath = "Path to his image"
                },
                new Person()
                {
                    Id = 4,
                    FirstName = "Dea",
                    LastName = "Tvildiani",
                    GenderId = Enums.GenderTypeEnum.Female,
                    PersonalNumber = "00000000000",
                    DateOfBirth = new DateTime(1993, 5, 25),
                    CityId = 2,
                    ImagePath = "Path to her image"
                });
            #endregion

            #region PhoneNumber Data Builder

            modelBuilder.Entity<PhoneNumber>().HasData(
                new PhoneNumber()
                {
                    Id = 1,
                    PhoneNumbers = "555159015",
                    NumberTypeId = Enums.NumberTypeEnum.Mobile,
                    PersonId = 1
                },
                new PhoneNumber()
                {
                    Id = 2,
                    PhoneNumbers = "555555555",
                    NumberTypeId = Enums.NumberTypeEnum.Office,
                    PersonId = 2
                },
                new PhoneNumber()
                {
                    Id = 3,
                    PhoneNumbers = "588888888",
                    NumberTypeId = Enums.NumberTypeEnum.Home,
                    PersonId = 3
                },
                new PhoneNumber()
                {
                    Id = 4,
                    PhoneNumbers = "599999999",
                    NumberTypeId = Enums.NumberTypeEnum.Mobile,
                    PersonId = 4
                });
            #endregion

            #region RelatedPerson Data Builder

            modelBuilder.Entity<RelatedPerson>().HasData(
                new RelatedPerson()
                {
                    Id = 1,
                    FirstName = "Giorgi",
                    LastName = "Giorgadze",
                    RelationTypeId = Enums.RelationTypeEnum.Colleague,
                    PersonId = 1
                },
                new RelatedPerson()
                {
                    Id = 2,
                    FirstName = "Nino",
                    LastName = "Darsavelidze",
                    RelationTypeId = Enums.RelationTypeEnum.Acquaintance,
                    PersonId = 2
                },
                new RelatedPerson()
                {
                    Id = 3,
                    FirstName = "Temuri",
                    LastName = "Tvildiani",
                    RelationTypeId = Enums.RelationTypeEnum.Relative,
                    PersonId = 3
                },
                new RelatedPerson()
                {
                    Id = 4,
                    FirstName = "Tamta",
                    LastName = "Mtchedlishvili",
                    RelationTypeId = Enums.RelationTypeEnum.Other,
                    PersonId = 4
                }
                ,
                new RelatedPerson()
                {
                    Id = 5,
                    FirstName = "Giorgi",
                    LastName = "Megreli",
                    RelationTypeId = Enums.RelationTypeEnum.Colleague,
                    PersonId = 1
                });
            #endregion
        }
        #endregion
    }
}
