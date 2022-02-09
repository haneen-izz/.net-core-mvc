using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Position1
    {
        public Position1()
        {
            Employee2s = new HashSet<Employee2>();
        }

        public short PositionId { get; set; }
        public string PositionName { get; set; }
        public short? BankNum { get; set; }

        public virtual Bank BankNumNavigation { get; set; }
        public virtual ICollection<Employee2> Employee2s { get; set; }
    }
}
