using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TreasureHunt.Models;
using TreasureHunt.Services;

namespace TreasureHunt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
		private readonly IConfiguration configuration;
		private readonly IUsersService usersService;

        public UsersController(
			IConfiguration configuration,
			IUsersService usersService)
        {
			this.configuration = configuration;
			this.usersService = usersService;
        }

		/// <summary>
		/// The GenerateJSONWebToken.
		/// </summary>
		/// <param name="claims">The claims<see cref="Claim[]"/>.</param>
		/// <returns>The <see cref="string"/>.</returns>
		private string GenerateJSONWebToken(Claim[] claims)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				this.configuration["Jwt:Issuer"],
				this.configuration["Jwt:Issuer"],
				claims,
				expires: DateTime.Now.AddMinutes(120),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		[HttpPost]
		[ActionName("user")]
		public async Task<AuthenticateResponse> AuthenticateUserAsync(User user)
		{
			var dbUser = await this.usersService.CreateUser(user);

			if (dbUser == null)
			{
				throw new UnauthorizedAccessException("Unauthorized");
			}

			return new AuthenticateResponse
			{
				Token = this.GenerateJSONWebToken(user),
				User = user,
			};
		}

		/// <summary>
		/// The GenerateJSONWebToken.
		/// </summary>
		/// <param name="user">The user<see cref="User"/>.</param>
		/// <returns>The <see cref="string"/>.</returns>
		private string GenerateJSONWebToken(User user)
		{
			var claims = new[] {
						new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
						new Claim(ClaimTypes.Name, user.LoginName),
						new Claim("FullName", user.Name),
						new Claim(JwtRegisteredClaimNames.Typ, "User"),
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) };

			return this.GenerateJSONWebToken(claims);
		}
	}
}