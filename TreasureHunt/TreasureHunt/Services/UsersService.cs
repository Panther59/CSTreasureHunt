using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreasureHunt.Data;
using TreasureHunt.Models;
namespace TreasureHunt.Services
{
	public class UsersService : IUsersService
	{
		private readonly TreasureHuntDBContext treasureHuntDBContext;
		private readonly IMapper mapper;

		public UsersService(
			TreasureHuntDBContext treasureHuntDBContext,
			IMapper mapper)
		{
			this.treasureHuntDBContext = treasureHuntDBContext;
			this.mapper = mapper;
		}

		/// <inheritdoc/>
		public async Task<User> CreateUser(User user)
		{
			var dbUser = await this.treasureHuntDBContext.Participants.FirstOrDefaultAsync(x => x.LoginName == user.LoginName);

			if (dbUser == null)
			{
				dbUser = this.mapper.MapUser(user);
				dbUser.CreatedOn = DateTime.Now;
				this.treasureHuntDBContext.Participants.Add(dbUser);
				await this.treasureHuntDBContext.SaveChangesAsync();
			}

			return this.mapper.MapUser(dbUser);
		}
	}
}
