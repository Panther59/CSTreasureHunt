// <copyright file="QuizzesService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-05-10</date>

namespace TreasureHunt.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;
	using TreasureHunt.Common;
	using TreasureHunt.Data;
	using TreasureHunt.Models;

	/// <summary>
	/// Defines the <see cref="QuizzesService" />.
	/// </summary>
	public class QuizzesService : IQuizzesService
	{
		/// <summary>
		/// Defines the mapper.
		/// </summary>
		private readonly IMapper mapper;

		/// <summary>
		/// Defines the session.
		/// </summary>
		private readonly ISession session;

		/// <summary>
		/// Defines the treasureHuntDBContext.
		/// </summary>
		private readonly TreasureHuntDBContext treasureHuntDBContext;

		/// <summary>
		/// Initializes a new instance of the <see cref="QuizzesService"/> class.
		/// </summary>
		/// <param name="session">The session<see cref="ISession"/>.</param>
		/// <param name="treasureHuntDBContext">The treasureHuntDBContext<see cref="TreasureHuntDBContext"/>.</param>
		/// <param name="mapper">The mapper<see cref="IMapper"/>.</param>
		public QuizzesService(
			ISession session,
			TreasureHuntDBContext treasureHuntDBContext,
			IMapper mapper)
		{
			this.session = session;
			this.treasureHuntDBContext = treasureHuntDBContext;
			this.mapper = mapper;
		}

		/// <inheritdoc />
		public async Task<List<Quiz>> GetActiveQuizzes()
		{
			var list = await this.treasureHuntDBContext.Quizzes.Where(x => x.Active).ToListAsync();

			var quizzes = list.Select(x => this.mapper.MapQuiz(x)).ToList();

			return quizzes;
		}

		/// <inheritdoc />
		public async Task<Question> GetNextQuestion(int quizId)
		{
			var question = await this.treasureHuntDBContext.Questions.FromSqlRaw("GetNextQuestion @participantId = {0}, @quizId = {1}", this.session.UserID.Value, quizId)
				.FirstOrDefaultAsync();

			return this.mapper.MapQuestion(question);
		}

		/// <inheritdoc />
		public async Task<Question> SubmitAnswer(Answer answer)
		{
			var question = this.treasureHuntDBContext.Questions
				.Include(x => x.Answers)
				.FirstOrDefault(x => x.Id == answer.Question.ID);

			if (question != null)
			{

				if (answer.Skipped == true)
				{
					var attempt = new Attempts()
					{
						AnswerId = null,
						ParticipantId = this.session.UserID.Value,
						ProgressedOn = DateTime.Now,
						QuestionId = question.Id,
						Skipped = true
					};

					this.treasureHuntDBContext.Attempts.Add(attempt);
					await this.treasureHuntDBContext.SaveChangesAsync();
				}
				else
				{
					var answerObj = question.Answers.FirstOrDefault(x => x.Title.Equals(answer.Title));
					if (answerObj != null)
					{
						var attempt = new Attempts()
						{
							AnswerId = answerObj.Id,
							ParticipantId = this.session.UserID.Value,
							ProgressedOn = DateTime.Now,
							QuestionId = question.Id,
							Skipped = false
						};

						this.treasureHuntDBContext.Attempts.Add(attempt);
						await this.treasureHuntDBContext.SaveChangesAsync();
					}
					else
					{
						throw new Exception("Answer is not valid");
					}
				}
			}

			return await GetNextQuestion(question.QuizId);
		}
	}
}
