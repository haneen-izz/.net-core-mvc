using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Report
    {
        public short ReportId { get; set; }
        public string ReportName { get; set; }
        public DateTime? ReportDate { get; set; }
        public short? BankNum { get; set; }

        public virtual Bank BankNumNavigation { get; set; }
    }
}
