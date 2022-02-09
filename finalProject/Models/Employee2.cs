using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Employee2
    {
        public short EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? DateOfDeployment { get; set; }
        public short? PositionId { get; set; }

        public virtual Position1 Position { get; set; }
    }
}
