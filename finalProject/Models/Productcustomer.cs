using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Productcustomer
    {
        public decimal Id { get; set; }
        public decimal? Productid { get; set; }
        public decimal? Customerid { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? Datefrom { get; set; }
        public DateTime? Dateto { get; set; }

        public virtual Customer1 Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
