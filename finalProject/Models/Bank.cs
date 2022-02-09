using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Bank
    {
        public Bank()
        {
            Accounts = new HashSet<Account>();
            Customers = new HashSet<Customer>();
            Position1s = new HashSet<Position1>();
            Reports = new HashSet<Report>();
        }

        public short BankNum { get; set; }
        public string BankName { get; set; }
        public string Address { get; set; }
        public int? PhoneNo { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Position1> Position1s { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
