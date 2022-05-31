using System;
using System.Collections.Generic;

namespace MVD.Models
{
    public partial class Participant
    {
        public Participant()
        {
            CriminalCaseDefendants = new HashSet<CriminalCase>();
            CriminalCaseWitnesses = new HashSet<CriminalCase>();
        }

        public int ParticipantId { get; set; }
        public string? ParticipantName { get; set; }
        public string? Surname { get; set; }
        public string? FatherName { get; set; }
        public string? Post { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? PasportNumber { get; set; }
        public int? CriminalCaseId { get; set; }

        public virtual CriminalCase? CriminalCase { get; set; }
        public virtual ICollection<CriminalCase> CriminalCaseDefendants { get; set; }
        public virtual ICollection<CriminalCase> CriminalCaseWitnesses { get; set; }
    }
}
