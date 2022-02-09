using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace finalProject.Models
{
    public partial class ProUser
    {
        public ProUser()
        {
            ProOrders = new HashSet<ProOrder>();
            ProPayments = new HashSet<ProPayment>();
            ProReviews = new HashSet<ProReview>();
            ProTestimonials = new HashSet<ProTestimonial>();
        }

        public decimal UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Phone { get; set; }
        [NotMapped]
        public string Password { get; set; }

        [NotMapped]
        public string Image { get; set; }

        [NotMapped]
        public virtual IFormFile ImageFile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal? RoleId { get; set; }
   

        public virtual ProRole Role { get; set; }
        public virtual ICollection<ProOrder> ProOrders { get; set; }
        public virtual ICollection<ProPayment> ProPayments { get; set; }
        public virtual ICollection<ProReview> ProReviews { get; set; }
        public virtual ICollection<ProTestimonial> ProTestimonials { get; set; }
    }
}
