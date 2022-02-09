using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Employee3
    {
        public decimal EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public decimal PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
