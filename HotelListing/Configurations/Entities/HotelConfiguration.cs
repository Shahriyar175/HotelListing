using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HotelListing.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
              new Hotel { Id = 1, Name = "Parmis", Address = "Kish", Rating = 4, CountryId = 1 },
              new Hotel { Id = 2, Name = "BNB", Address = "Berlin", Rating = 3, CountryId = 2 },
              new Hotel { Id = 3, Name = "Hilton", Address = "Newyork", Rating = 4.5, CountryId = 3 }
              );
        }
    }
}
