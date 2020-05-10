using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TreasureHunt.Common;
using TreasureHunt.Data;
using TreasureHunt.Models;

namespace TreasureHunt.Services
{
	public class ResultService : IResultService
	{
		private readonly TreasureHuntDBContext treasureHuntDBContext;
		private readonly ISession session;

		public ResultService(TreasureHuntDBContext treasureHuntDBContext, ISession session)
		{
			this.treasureHuntDBContext = treasureHuntDBContext;
			this.session = session;
		}

		/// <inheritdoc/>
		public async Task<List<Result>> GetLiveResult(int quizId)
		{
			using var connection = this.treasureHuntDBContext.Database.GetDbConnection();
			await connection.OpenAsync();
			using var cmd = connection.CreateCommand();
			cmd.CommandText = "GetLiveResult";
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("@quizId", quizId));
			cmd.Parameters.Add(new SqlParameter("@userId", this.session.UserID.Value));
			List<Result> results = new List<Result>();

			using (var rdr = await cmd.ExecuteReaderAsync())
			{
				//3. Loop through rows
				while (rdr.Read())
				{
					var result = new Result();
					result.User = new User();
					result.User.ID = rdr.GetInt32(0);
					result.User.Name = rdr.GetString(1);
					result.User.LoginName = rdr.GetString(2);
					result.Answered = rdr.GetInt32(4);
					result.Total = rdr.GetInt32(5);
					result.Rank = (int)rdr.GetInt64(6);
					//Get each column
					results.Add(result);
				}
			}

			return results;
		}
	}
}
