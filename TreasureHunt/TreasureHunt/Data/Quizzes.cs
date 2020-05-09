using System;
using System.Collections.Generic;

namespace TreasureHunt.Data
{
    public partial class Quizzes
    {
        public Quizzes()
        {
            Questions = new HashSet<Questions>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Type { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
    }
}
