using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Room
    {
        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
