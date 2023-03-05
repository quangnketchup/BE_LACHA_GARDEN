using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Area
    {
        public Area()
        {
            Buildings = new HashSet<Building>();
        }

        public int Id { get; set; }
        public string NameArea { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
    }
}
