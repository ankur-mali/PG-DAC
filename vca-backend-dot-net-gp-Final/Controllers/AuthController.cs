using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VCA.Models;
using VCA.Services.Registrations;


namespace VCA.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IRegistrationRepository _registrationService;

        public AuthController(IRegistrationRepository registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login company)
        {
            try
            {
                // Authenticate the user here and generate a JWT token upon successful login
                // You should replace this with your actual authentication logic

                // If authentication is successful, generate a JWT token
                // string jwtToken = GenerateJwtToken(loginRequest.Username); // Replace with your token generation logic
                Registration existComp = await _registrationService.FindByUsernameAsync(company.Email);
                if (existComp == null || existComp.Password != company.Password)
                {
                    return BadRequest("Invalid Credential");
                }

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, existComp.Email),
                    // You can add more claims as needed
                };
                // Use a secret key to sign the token
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyHere"));
                // Generate the token
                var token = new JwtSecurityToken(
                    issuer: "YourIssuer",
                    audience: "YourAudience",
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1), // Set the token expiration time
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
                // Serialize the token to a string
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                var responseData = new Dictionary<string, object>
                {
                    { "jwt", jwtToken },
                    { "id", existComp.Id},
                    { "username", existComp.AuthorizedPersonName},
                    { "status", 200}
                    // Add token if needed
                };

                

                return Ok(new Dictionary<string, object>() { { "data", new Dictionary<string, object>() { { "data", responseData } } } });
            }
            catch (Exception e)
            {
                // Handle authentication failure
                var errorResponse = new Dictionary<string, object>
                {
                    { "status", "error" },
                    { "message", "Authentication failed" } // Customize this message
                };
                return StatusCode(StatusCodes.Status401Unauthorized, errorResponse);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Registration registration)
        {
            try
            {
                // Implement your registration logic here
                var existingRegistration = await _registrationService.FindByUsernameAsync(registration.Email);
                if (existingRegistration != null)
                {
                    return BadRequest("Username already exists");
                }

                // Implement your validation logic if needed
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _registrationService.CreateRegistrationAsync(registration);

                return Ok("Registration successful");
            }
            catch (Exception e)
            {
                var errorResponse = new Dictionary<string, object>
                {
                    { "status", "error" },
                    { "message", "Authentication failed" }
                };
                return StatusCode(StatusCodes.Status400BadRequest, errorResponse);
            }
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetRegistrationById(int id)
        {
            try
            {
                // Implement your logic to retrieve a Registration by ID from your repository
                var registration = await _registrationService.GetRegistrationByIdAsync(id);

                if (registration == null)
                {
                    return NotFound("Registration not found");
                }

                // You may want to project the registration data to a DTO if needed
                // var registrationDto = MapToDto(registration);

                return Ok(registration);
            }
            catch (Exception e)
            {
                var errorResponse = new Dictionary<string, object>
        {
            { "status", "error" },
            { "message", "Failed to retrieve registration" }
        };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

    }
}
