using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class ProReview
    {
        public decimal ReviewId { get; set; }
        public decimal? UserId { get; set; }
        public decimal Rating { get; set; }
        public string Message { get; set; }

        public virtual ProUser User { get; set; }
    }
}
