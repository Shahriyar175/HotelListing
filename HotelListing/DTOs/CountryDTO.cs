using HotelListing.Data;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.DTOs
{
    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength:50, ErrorMessage ="Country Name is too long!")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength:2, ErrorMessage ="Country Short name is too long!")]
        public string ShortName { get; set; } = string.Empty;

    }

    public class CountryDTO: CreateCountryDTO
    {
        public int Id { get; set; }

        public List<HotelSummaryDTO> Hotels { get; set; }
    }

    public class CountrySummaryDTO: CreateCountryDTO
    {
        public int Id { get; set; }
    }
}
