// <copyright file="IQuizzesService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-09</date>

namespace TreasureHunt.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using TreasureHunt.Models;

	/// <summary>
	/// Defines the <see cref="IQuizzesService" />.
	/// </summary>
	public interface IQuizzesService
	{
		/// <summary>
		/// The GetActiveQuizzes.
		/// </summary>
		/// <returns>The <see cref="Task{List{Quiz}}"/>.</returns>
		Task<List<Quiz>> GetActiveQuizzes();

		/// <summary>
		/// The GetNextQuestion.
		/// </summary>
		/// <param name="user">The user<see cref="User"/>.</param>
		/// <param name="quizId">The quizId<see cref="int"/>.</param>
		/// <returns>The <see cref="Task{Question}"/>.</returns>
		Task<Question> GetNextQuestion(User user, int quizId);

		/// <summary>
		/// The SubmitAnswer.
		/// </summary>
		/// <param name="user">The user<see cref="User"/>.</param>
		/// <param name="answer">The answer<see cref="Answer"/>.</param>
		/// <returns>The <see cref="Task{Question}"/>.</returns>
		Task<Question> SubmitAnswer(User user, Answer answer);
	}
}
