using System.ComponentModel.DataAnnotations;

namespace HotelListing.DTOs
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(15,ErrorMessage = "Password is limited to {2} and {1} characters", MinimumLength =4)]
        public string Password { get; set; } = string.Empty;

    }

    public class UserDTO : LoginUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        public ICollection<string> Roles { get; set; }

    }
}
