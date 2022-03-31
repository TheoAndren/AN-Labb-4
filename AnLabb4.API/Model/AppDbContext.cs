using AN_Labb_4;
using Microsoft.EntityFrameworkCore;

namespace AnLabb4.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<PersonInterestLink> PersonInterestLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person { 
                PersonId = 1, 
                FirstName = "Anas", 
                LastName = "Qlok", 
                PhoneNumber = "072542302" });
            modelBuilder.Entity<Person>().HasData(new Person { 
                PersonId = 2, 
                FirstName = "Tobias", 
                LastName = "Qlok", 
                PhoneNumber = "0734242" });
            modelBuilder.Entity<Person>().HasData(new Person { 
                PersonId = 3, 
                FirstName = "Reidar", 
                LastName = "Qlok", 
                PhoneNumber = "074241" });


            modelBuilder.Entity<Interest>().HasData(new Interest { 
                InterestId = 1, 
                InterestTitle = "Hockey", 
                Description = "Hockey is a team based sport played 5v5 + a goalie" });
            modelBuilder.Entity<Interest>().HasData(new Interest { 
                InterestId = 2, 
                InterestTitle = "Floorball", 
                Description = "Floorball is a team based sport played 5v5 + a goalie" });
            modelBuilder.Entity<Interest>().HasData(new Interest { 
                InterestId = 3, 
                InterestTitle = "LeagueOfLegends", 
                Description = "League of legends is a team based strategy computer game played 5v5" });

            modelBuilder.Entity<Website>().HasData(new Website { 
                WebsiteId = 1, 
                Link = "https://www.laget.se/KungsbackaHC"
            });
            modelBuilder.Entity<Website>().HasData(new Website { 
                WebsiteId = 2, 
                Link = "https://www.varlaibk.nu/start/?ID=16231"
            });
            modelBuilder.Entity<Website>().HasData(new Website { 
                WebsiteId = 3, 
                Link = "https://www.leagueoflegends.com/en-gb/"
            });

            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { 
                Id = 1, 
                PersonId = 1, 
                InterestId = 2, 
                WebsiteId = 2 });
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { 
                Id = 2, 
                PersonId = 2, 
                InterestId = 1, 
                WebsiteId = 1 });
            modelBuilder.Entity<PersonInterestLink>().HasData(new PersonInterestLink { 
                Id = 3, 
                PersonId = 3, 
                InterestId = 3, 
                WebsiteId = 3 });
            
        }
    }
}
