using System;
using System.Collections.Generic;

#nullable disable

namespace Ahad_Project.Models
{
    public partial class Interview
    {
        public Interview()
        {
            Schedules = new HashSet<Schedule>();
        }

        public byte Id { get; set; }
        public byte? VacId { get; set; }
        public int? InterviewerOne { get; set; }
        public int? InterviewerTwo { get; set; }
        public int? InterviewerThree { get; set; }

        public virtual Employee InterviewerOneNavigation { get; set; }
        public virtual Employee InterviewerThreeNavigation { get; set; }
        public virtual Employee InterviewerTwoNavigation { get; set; }
        public virtual Vacancy Vac { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
