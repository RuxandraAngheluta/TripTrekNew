using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TripTrek.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripTrek.Data;
using Microsoft.Extensions.Configuration;

namespace TripTrek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly PiiContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(PiiContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserData userRegistrationDto)
        {
            var account = new Account
            {
                Email = userRegistrationDto.Email,
                PhoneNr = 0, // Add a valid phone number if necessary
                Password = BCrypt.Net.BCrypt.HashPassword(userRegistrationDto.Password)
            };

            var user = new User
            {
                FirstName = userRegistrationDto.FirstName,
                LastName = userRegistrationDto.LastName,
                BirthDate = userRegistrationDto.BirthDate,
                Email = userRegistrationDto.Email,
                Password = account.Password,
                Account = account
            };

            _context.Accounts.Add(account);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AccountData loginDto)
        {

            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == loginDto.Email);
            if (account == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, account.Password))
                return BadRequest("Invalid username or password");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.AccountId == account.Id);
             return Ok(new { Token = await CreateTokenAsync(user) });
            //return Ok();
        }

        private async Task<string> CreateTokenAsync(User user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}