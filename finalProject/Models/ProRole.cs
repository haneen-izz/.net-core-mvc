using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class ProRole
    {
        public ProRole()
        {
            ProLoginandregs = new HashSet<ProLoginandreg>();
            ProUsers = new HashSet<ProUser>();
        }

        public decimal RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<ProLoginandreg> ProLoginandregs { get; set; }
        public virtual ICollection<ProUser> ProUsers { get; set; }
    }
}
