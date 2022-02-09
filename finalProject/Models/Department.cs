using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee3s = new HashSet<Employee3>();
        }

        public decimal DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Employee3> Employee3s { get; set; }
    }
}
