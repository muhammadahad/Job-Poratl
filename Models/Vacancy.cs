using System;
using System.Collections.Generic;

#nullable disable

namespace Ahad_Project.Models
{
    public partial class Vacancy
    {
        public Vacancy()
        {
            Interviews = new HashSet<Interview>();
        }

        public byte Id { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime EndedDate { get; set; }
        public byte? DepId { get; set; }

        public virtual Department Dep { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
