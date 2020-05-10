using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreasureHunt.Models;

namespace TreasureHunt.Services
{
	public class ResultService : IResultService
	{
		/// <inheritdoc/>
		public Task<List<Result>> GetLiveResult(int quizId)
		{
			return null;
		}
	}
}
