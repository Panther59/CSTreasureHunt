// <copyright file="ResultController.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-10</date>

namespace TreasureHunt.Controllers
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using TreasureHunt.Filters;
	using TreasureHunt.Models;
	using TreasureHunt.Services;

	/// <summary>
	/// Defines the <see cref="ResultController" />.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	[LoginAuthorize]
	public class ResultController : ControllerBase
	{
		private readonly IResultService resultService;

		/// <summary>
		/// Initializes a new instance of the <see cref="QuizController"/> class.
		/// </summary>
		/// <param name="resultService">The quizzesService<see cref="IQuizzesService"/>.</param>
		public ResultController(
			IResultService resultService)
		{
			this.resultService = resultService;
		}

		/// <summary>
		/// The GetActiveQuizzes.
		/// </summary>
		/// <returns>The <see cref="Task{List{Quiz}}"/>.</returns>
		[HttpGet]
		[ActionName("{quizId}/get")]
		public async Task<List<Result>> GetLiveResult(int quizId)
		{
			var results = await this.resultService.GetLiveResult(quizId);

			return results;
		}
	}
}
