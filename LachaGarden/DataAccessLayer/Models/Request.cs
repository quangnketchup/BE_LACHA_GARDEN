using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Request
    {
        public Request()
        {
            TreeCares = new HashSet<TreeCare>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public int? GardenId { get; set; }

        public virtual Garden Garden { get; set; }
        public virtual ICollection<TreeCare> TreeCares { get; set; }
    }
}
