using System;
using System.Collections.Generic;

#nullable disable

namespace Ahad_Project.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public byte InterviewId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public virtual Interview Interview { get; set; }
    }
}
