using System;
using System.Collections.Generic;

#nullable disable

namespace Ahad_Project.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Vacancies = new HashSet<Vacancy>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
