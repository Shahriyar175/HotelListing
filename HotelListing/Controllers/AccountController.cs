using AutoMapper;
using HotelListing.Data;
using HotelListing.DTOs;
using HotelListing.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController:ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<ApiUser> userManager, IMapper mapper, ILogger<AccountController> logger, IAuthManager authManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"User registration attempt for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user, userDTO.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(Register)}");
                return Problem("Internal server error", statusCode:500);
            }
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task <IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            _logger.LogInformation($"Login attempt for user {loginUserDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!await _authManager.ValidateUserAsync(loginUserDTO))
                {
                    return Unauthorized();
                }

                return Accepted(new { Token = await _authManager.CreateTokenAsync() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(Login)}");
                return Problem("Internal sever error", statusCode: 500);
            }
        }
    }
}
