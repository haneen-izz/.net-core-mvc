using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class ProProductOrder
    {
        public decimal Id { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? OrderId { get; set; }

        public virtual ProOrder Order { get; set; }
        public virtual ProProduct Product { get; set; }
    }
}
