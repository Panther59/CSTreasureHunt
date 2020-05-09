using System;
using System.Collections.Generic;

namespace TreasureHunt.Data
{
    public partial class Attempts
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public bool? Skipped { get; set; }
        public DateTime? ProgressedOn { get; set; }

        public virtual Answers Answer { get; set; }
        public virtual Participants Participant { get; set; }
        public virtual Questions Question { get; set; }
    }
}
