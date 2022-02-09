using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class ProTestimonial
    {
        public decimal TestimonialId { get; set; }
        public string TestimonialText { get; set; }
        public decimal? UserId { get; set; }

        public virtual ProUser User { get; set; }
    }
}
