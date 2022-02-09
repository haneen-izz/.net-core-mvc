using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class ProContact
    {
        public ProContact()
        {
            ProHomepages = new HashSet<ProHomepage>();
        }

        public decimal ContactId { get; set; }
        public string Name { get; set; }
        public decimal? Age { get; set; }
        public string Email { get; set; }
        public decimal? Phone { get; set; }

        public virtual ICollection<ProHomepage> ProHomepages { get; set; }
    }
}
