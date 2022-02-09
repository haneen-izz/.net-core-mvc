using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class ProAbout
    {
        public ProAbout()
        {
            ProHomepages = new HashSet<ProHomepage>();
        }

        public decimal AboutId { get; set; }
        public string Text2 { get; set; }

        public virtual ICollection<ProHomepage> ProHomepages { get; set; }
    }
}
