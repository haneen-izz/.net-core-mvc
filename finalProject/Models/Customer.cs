using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
        }

        public short CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public short? BankNum { get; set; }

        public virtual Bank BankNumNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
