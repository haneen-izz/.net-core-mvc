using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace finalProject.Models
{
    public partial class ProCategory
    {
        public ProCategory()
        {
            ProProducts = new HashSet<ProProduct>();
        }

        public decimal CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }


        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }

        public virtual ICollection<ProProduct> ProProducts { get; set; }
    }
}
