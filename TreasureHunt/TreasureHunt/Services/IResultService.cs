// <copyright file="IResultService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-10</date>

namespace TreasureHunt.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using TreasureHunt.Models;

	/// <summary>
	/// Defines the <see cref="IResultService" />.
	/// </summary>
	public interface IResultService
	{
		/// <summary>
		/// The GetLiveResult.
		/// </summary>
		/// <param name="quizId">The quizId<see cref="int"/>.</param>
		/// <returns>The <see cref="Task{List{Result}}"/>.</returns>
		Task<List<Result>> GetLiveResult(int quizId);
	}
}
