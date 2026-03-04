using HotelListing.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.DTOs
{
    public class CreateHotelDTO
    {
        [Required]
        [StringLength(50, ErrorMessage ="Hotel Name is too long!")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(150, ErrorMessage ="Address is too long!")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Range(1,5)]
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
    
    public class HotelDTO: CreateHotelDTO
    {
        public int Id { get; set; }

        public CountrySummaryDTO Country { get; set; }

    }

    public class HotelSummaryDTO : CreateHotelDTO
    {
        public int Id { get; set; }
    }
}
