using System;
using System.Collections.Generic;

namespace MVD.Models
{
    public partial class CriminalCase
    {
        public CriminalCase()
        {
            Participants = new HashSet<Participant>();
        }

        public int CriminalCaseId { get; set; }
        public int? InterrogatorId { get; set; }
        public int? WitnessId { get; set; }
        public int? DefendantId { get; set; }
        public DateTime? CreatingDate { get; set; }
        public string? Location { get; set; }

        public virtual Participant? Defendant { get; set; }
        public virtual Interrogator? Interrogator { get; set; }
        public virtual Participant? Witness { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
