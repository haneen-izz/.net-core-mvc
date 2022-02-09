using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class ProLoginandreg
    {
        //public ProLoginandreg()
        //{
        //    ProUsers = new HashSet<ProUser>();
        //}

        public decimal LoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public decimal? RoleId { get; set; }

        public virtual ProRole Role { get; set; }
        //public virtual ICollection<ProUser> ProUsers { get; set; }
    }
}
