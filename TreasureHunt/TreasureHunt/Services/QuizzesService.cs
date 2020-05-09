using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreasureHunt.Data;
using TreasureHunt.Models;

namespace TreasureHunt.Services
{
	public class QuizzesService : IQuizzesService
	{
		private readonly TreasureHuntDBContext treasureHuntDBContext;
		private readonly IMapper mapper;

		public QuizzesService(
			TreasureHuntDBContext treasureHuntDBContext,
			IMapper mapper)
		{
			this.treasureHuntDBContext = treasureHuntDBContext;
			this.mapper = mapper;
		}

		public async Task<List<Quiz>> GetActiveQuizzes()
		{
			var list = await this.treasureHuntDBContext.Quizzes.Where(x => x.Active).ToListAsync();

			var quizzes = list.Select(x => this.mapper.MapQuiz(x)).ToList();

			return quizzes;
		}

		public async Task<Question> GetNextQuestion(User user, int quizId)
		{
			var question = await this.treasureHuntDBContext.Questions.FromSqlRaw("GetNextQuestion @participantId = {0}, @quizId = {1}", user.ID, quizId)
				.FirstOrDefaultAsync();

			return this.mapper.MapQuestion(question);
		}

		public async Task<Question> SubmitAnswer(User user, Answer answer)
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
						ParticipantId = user.ID.Value,
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
							ParticipantId = user.ID.Value,
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

			return await GetNextQuestion(user, question.QuizId);
		}
	}
}
