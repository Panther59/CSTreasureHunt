using System;
using System.Collections.Generic;

namespace TreasureHunt.Data
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
            Attempts = new HashSet<Attempts>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int QuizId { get; set; }
        public int Sequance { get; set; }
        public int? SkippedDurationSeconds { get; set; }

        public virtual Quizzes Quiz { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<Attempts> Attempts { get; set; }
    }
}
