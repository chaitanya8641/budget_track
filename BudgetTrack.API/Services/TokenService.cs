using BudgetTrack.API.Services.Interfaces;
using BudgetTrack.Common;
using BudgetTrack.Data;
using BudgetTrack.Domain.DTOs.Auth.Request;
using BudgetTrack.Domain.DTOs.Auth.Response;
using BudgetTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BudgetTrack.API.Services
{
    public class TokenService: ITokenService
    {
        private readonly AppSettings _appSettings;
        private readonly BudgetContext _budgetDbContext;
        public TokenService(IOptions<AppSettings> appSettings, BudgetContext budgetDbContext)
        {
            _appSettings = appSettings.Value;
            _budgetDbContext = budgetDbContext;
        }
        public async Task<AuthResponse> Authenticate(AuthRequest authRequest)
        {
            AuthResponse response = new();
            var user = await _budgetDbContext.Users.Where(x => x.UserName == authRequest.Username && x.Password == authRequest.Password).SingleOrDefaultAsync();
            if (user != null)
            {
                response.Token = GenerateJwtToken(user);
            }
            return response;
        }

        private string GenerateJwtToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.SecretKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>() {

                new Claim("UserId" , user.Id.ToString()),
            };

            var tokeOptions = new JwtSecurityToken(
                issuer: _appSettings.Issuer,
                audience: _appSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_appSettings.Expires)),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }
    }
}
