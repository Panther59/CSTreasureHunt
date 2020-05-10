// <copyright file="QuizController.cs" company="Ayvan">
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
	/// Defines the <see cref="QuizController" />.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	[LoginAuthorize]
	public class QuizController : ControllerBase
	{
		/// <summary>
		/// Defines the quizzesService.
		/// </summary>
		private readonly IQuizzesService quizzesService;

		/// <summary>
		/// Initializes a new instance of the <see cref="QuizController"/> class.
		/// </summary>
		/// <param name="quizzesService">The quizzesService<see cref="IQuizzesService"/>.</param>
		public QuizController(
			IQuizzesService quizzesService)
		{
			this.quizzesService = quizzesService;
		}

		/// <summary>
		/// The GetActiveQuizzes.
		/// </summary>
		/// <returns>The <see cref="Task{List{Quiz}}"/>.</returns>
		[HttpGet]
		[ActionName("getAll")]
		public async Task<List<Quiz>> GetActiveQuizzes()
		{
			var quizzes = await this.quizzesService.GetActiveQuizzes();

			return quizzes;
		}

		/// <summary>
		/// The GetNextQuestion.
		/// </summary>
		/// <param name="answer">The answer<see cref="Answer"/>.</param>
		/// <returns>The <see cref="Task{Question}"/>.</returns>
		[HttpPost]
		[ActionName("answer")]
		public async Task<Question> GetNextQuestion(Answer answer)
		{
			var question = await this.quizzesService.SubmitAnswer(answer);

			return question;
		}

		/// <summary>
		/// The GetNextQuestion.
		/// </summary>
		/// <param name="quizId">The quizId<see cref="int"/>.</param>
		/// <returns>The <see cref="Task{Question}"/>.</returns>
		[HttpGet]
		[ActionName("{quizId}/nextQuestion")]
		public async Task<Question> GetNextQuestion(int quizId)
		{
			var question = await this.quizzesService.GetNextQuestion(quizId);

			return question;
		}
	}
}
