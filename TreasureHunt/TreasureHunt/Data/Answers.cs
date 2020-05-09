using System;
using System.Collections.Generic;

namespace TreasureHunt.Data
{
    public partial class Answers
    {
        public Answers()
        {
            Attempts = new HashSet<Attempts>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }

        public virtual Questions Question { get; set; }
        public virtual ICollection<Attempts> Attempts { get; set; }
    }
}
