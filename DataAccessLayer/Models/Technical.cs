using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Technical
    {
        public Technical()
        {
            TreeCares = new HashSet<TreeCare>();
        }

        public int Id { get; set; }
        public string NameTech { get; set; }
        public string Gmail { get; set; }
        public decimal? Phone { get; set; }
        public string Image { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<TreeCare> TreeCares { get; set; }
    }
}
