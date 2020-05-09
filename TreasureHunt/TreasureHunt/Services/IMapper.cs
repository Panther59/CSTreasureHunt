// <copyright file="IMapper.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-09</date>

namespace TreasureHunt.Services
{
	using TreasureHunt.Data;
	using TreasureHunt.Models;

	/// <summary>
	/// Defines the <see cref="IMapper" />.
	/// </summary>
	public interface IMapper
	{
		/// <summary>
		/// The MapQuestion.
		/// </summary>
		/// <param name="question">The question<see cref="Questions"/>.</param>
		/// <returns>The <see cref="Question"/>.</returns>
		Question MapQuestion(Questions question);

		/// <summary>
		/// The MapQuiz.
		/// </summary>
		/// <param name="quiz">The x<see cref="Quizzes"/>.</param>
		/// <returns>The <see cref="Quiz"/>.</returns>
		Quiz MapQuiz(Quizzes quiz);

		/// <summary>
		/// The MapUser.
		/// </summary>
		/// <param name="user">The user<see cref="Participants"/>.</param>
		/// <returns>The <see cref="User"/>.</returns>
		User MapUser(Participants user);

		/// <summary>
		/// The MapUser.
		/// </summary>
		/// <param name="user">The user<see cref="User"/>.</param>
		/// <returns>The <see cref="Participants"/>.</returns>
		Participants MapUser(User user);
	}
}
