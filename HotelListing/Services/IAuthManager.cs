using HotelListing.DTOs;

namespace HotelListing.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUserAsync(LoginUserDTO userDTO);
        Task<string> CreateTokenAsync();
    }
}
