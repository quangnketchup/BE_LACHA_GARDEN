using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Role
    {
        public Role()
        {
            Customers = new HashSet<Customer>();
            Technicals = new HashSet<Technical>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Technical> Technicals { get; set; }
    }
}
