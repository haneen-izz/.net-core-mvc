using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Contactinfo
    {
        public Contactinfo()
        {
            Employee21s = new HashSet<Employee21>();
        }

        public int ContactId { get; set; }
        public int? Phonenumber { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Employee21> Employee21s { get; set; }
    }
}
