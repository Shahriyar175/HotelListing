using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Iran", ShortName = "IR" },
                new Country { Id = 2, Name = "Germany", ShortName = "GE" },
                new Country { Id = 3, Name = "USA", ShortName = "US" }
                );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id =1, Name = "Parmis" , Address = "Kish", Rating = 4, CountryId = 1},
                new Hotel { Id = 2 , Name = "BNB", Address ="Berlin", Rating = 3, CountryId = 2},
                new Hotel { Id = 3 , Name = "Hilton" , Address = "Newyork", Rating=4.5 , CountryId = 3}
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
