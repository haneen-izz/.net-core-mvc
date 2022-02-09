using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Position
    {
        public Position()
        {
            Employee1s = new HashSet<Employee1>();
        }

        public decimal PositionId { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<Employee1> Employee1s { get; set; }
    }
}
