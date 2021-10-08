using System;
using System.Collections.Generic;

#nullable disable

namespace Ahad_Project.Models
{
    public partial class Mailing
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
