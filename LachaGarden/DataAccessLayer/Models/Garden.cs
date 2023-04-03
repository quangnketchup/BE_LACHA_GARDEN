using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Garden
    {
        public Garden()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public int? Status { get; set; }
        public int? GardenPackageId { get; set; }
        public DateTime? DateTime { get; set; }
        public int? RoomId { get; set; }

        public virtual GardenPackage GardenPackage { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
