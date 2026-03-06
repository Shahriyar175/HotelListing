using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HotelListing.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
               new Country { Id = 1, Name = "Iran", ShortName = "IR" },
               new Country { Id = 2, Name = "Germany", ShortName = "GE" },
               new Country { Id = 3, Name = "USA", ShortName = "US" }
               );
        }
    }
}
