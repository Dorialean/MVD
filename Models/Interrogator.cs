using System;
using System.Collections.Generic;

namespace MVD.Models
{
    public partial class Interrogator
    {
        public Interrogator()
        {
            CriminalCases = new HashSet<CriminalCase>();
        }

        public int InterrogatorId { get; set; }
        public string? InterrogatorName { get; set; }
        public string? Surname { get; set; }
        public string? FatherName { get; set; }
        public string? Post { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDay { get; set; }
        public decimal? Salary { get; set; }

        public virtual ICollection<CriminalCase> CriminalCases { get; set; }
    }
}
