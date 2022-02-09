using System;
using System.Collections.Generic;

#nullable disable

namespace finalProject.Models
{
    public partial class Address
    {
        public Address()
        {
            Contactinfos = new HashSet<Contactinfo>();
            Department1s = new HashSet<Department1>();
        }

        public int AddressId { get; set; }
        public string Addressname { get; set; }

        public virtual ICollection<Contactinfo> Contactinfos { get; set; }
        public virtual ICollection<Department1> Department1s { get; set; }
    }
}
