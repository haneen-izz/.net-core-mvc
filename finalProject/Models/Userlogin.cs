using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Userlogin
    {
        public decimal Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Customerid { get; set; }

        public virtual Customer1 Customer { get; set; }
    }
}
