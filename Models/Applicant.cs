using System;
using System.Collections.Generic;

#nullable disable

namespace Ahad_Project.Models
{
    public partial class Applicant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string UploadFile { get; set; }
    }
}
