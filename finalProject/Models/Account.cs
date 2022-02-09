using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Account
    {
        public short AccountNum { get; set; }
        public decimal Balance { get; set; }
        public string Type { get; set; }
        public short? BankNum { get; set; }
        public short? CustomerId { get; set; }

        public virtual Bank BankNumNavigation { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
