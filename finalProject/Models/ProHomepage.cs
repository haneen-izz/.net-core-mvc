using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace finalProject.Models
{
    public partial class ProHomepage
    {
        public decimal Id { get; set; }
        public decimal? ContactId { get; set; }
        public decimal? AboutId { get; set; }

        [NotMapped]
        public string Image { get; set; }


        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }


        public virtual ProAbout About { get; set; }
        public virtual ProContact Contact { get; set; }
    }
}
