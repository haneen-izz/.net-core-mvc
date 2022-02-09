using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace finalProject.Models
{
    public partial class ProProduct
    {
        public ProProduct()
        {
            ProProductOrders = new HashSet<ProProductOrder>();
        }

        public decimal ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Sale { get; set; }
        public decimal? Cost { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }
        public decimal? CategoryId { get; set; }

        public virtual ProCategory Category { get; set; }
        public virtual ICollection<ProProductOrder> ProProductOrders { get; set; }
    }
}
