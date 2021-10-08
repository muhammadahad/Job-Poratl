using System;
using System.Collections.Generic;

#nullable disable

namespace Ahad_Project.Models
{
    public partial class Employee
    {
        public Employee()
        {
            InterviewInterviewerOneNavigations = new HashSet<Interview>();
            InterviewInterviewerThreeNavigations = new HashSet<Interview>();
            InterviewInterviewerTwoNavigations = new HashSet<Interview>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? Gender { get; set; }
        public string Contact { get; set; }
        public byte? DepId { get; set; }

        public virtual Department Dep { get; set; }
        public virtual ICollection<Interview> InterviewInterviewerOneNavigations { get; set; }
        public virtual ICollection<Interview> InterviewInterviewerThreeNavigations { get; set; }
        public virtual ICollection<Interview> InterviewInterviewerTwoNavigations { get; set; }
    }
}
