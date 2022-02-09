using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class ProPayment
    {
        public decimal PaymentId { get; set; }
        public string CardName { get; set; }
        public string CardNum { get; set; }
        public decimal? Amount { get; set; }
        public DateTime CardExp { get; set; }
        public decimal? UserId { get; set; }

        public virtual ProUser User { get; set; }
    }
}
