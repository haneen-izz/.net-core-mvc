using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Patient
    {
        public decimal Patientname { get; set; }
        public string Patientnumber { get; set; }

        public virtual Room PatientnameNavigation { get; set; }
    }
}
