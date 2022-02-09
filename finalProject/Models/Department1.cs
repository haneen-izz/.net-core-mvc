using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Department1
    {
        public Department1()
        {
            Employee21s = new HashSet<Employee21>();
        }

        public int DepartmentId { get; set; }
        public string Departmentname { get; set; }
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Employee21> Employee21s { get; set; }
    }
}
