using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public decimal Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Imagepath { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
