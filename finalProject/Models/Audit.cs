using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Audit
    {
        public decimal AuditId { get; set; }
        public string TableName { get; set; }
        public string TransactionName { get; set; }
        public string ByUser { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
