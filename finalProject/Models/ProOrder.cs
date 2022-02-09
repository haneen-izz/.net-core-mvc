using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class ProOrder
    {
        public ProOrder()
        {
            ProProductOrders = new HashSet<ProProductOrder>();
        }

        public decimal OrderId { get; set; }
        public decimal? UserId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? ProductId { get; set; }
        public decimal? Sales { get; set; }
        public DateTime? OrdersDate { get; set; }

        public virtual ProUser User { get; set; }
        public virtual ICollection<ProProductOrder> ProProductOrders { get; set; }
    }
}
