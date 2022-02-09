using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Employee21
    {
        public int EmployeeId { get; set; }
        public string Employeename { get; set; }
        public decimal? Salary { get; set; }
        public int? ContactId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Contactinfo Contact { get; set; }
        public virtual Department1 Department { get; set; }
    }
}
