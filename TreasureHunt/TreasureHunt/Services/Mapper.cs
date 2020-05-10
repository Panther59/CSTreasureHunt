using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreasureHunt.Data;
using TreasureHunt.Models;

namespace TreasureHunt.Services
{
	public class Mapper : IMapper
	{
		public Question MapQuestion(Questions question)
		{
			return question == null ? null : new Question
			{
				ID = question.Id,
				Sequance = question.Sequance,
				SkippedDurationSeconds = question.SkippedDurationSeconds,
				Title = question.Title
			};
		}

		public Quiz MapQuiz(Quizzes quiz)
		{
			return quiz == null ? null : new Quiz
			{
				Active = quiz.Active,
				EndTime = quiz.EndTime,
				ID = quiz.Id,
				StartTime = quiz.StartTime,
				Title = quiz.Title,
				Type = quiz.Type
			};
		}

		public User MapUser(Participants user)
		{
			return user == null ? null : new User
			{
				ID = user.Id,
				LoginName = user.LoginName,
				Name = user.Name
			};
		}

		public Participants MapUser(User user)
		{
			return user == null ? null : new Participants
			{
				Id = user.ID.Value,
				LoginName = user.LoginName,
				Name = user.Name
			};
		}
	}
}
