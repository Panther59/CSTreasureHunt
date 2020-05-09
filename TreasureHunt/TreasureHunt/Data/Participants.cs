using System;
using System.Collections.Generic;

namespace TreasureHunt.Data
{
    public partial class Participants
    {
        public Participants()
        {
            Attempts = new HashSet<Attempts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Attempts> Attempts { get; set; }
    }
}
