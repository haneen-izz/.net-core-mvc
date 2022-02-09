using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Employee1
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal? PosId { get; set; }
        public decimal? PhoneNo { get; set; }
        public decimal? Salary { get; set; }

        public virtual Position Pos { get; set; }
    }
}
