using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class TreeCare
    {
        public TreeCare()
        {
            Results = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string UserId { get; set; }
        public int? RequestId { get; set; }

        public virtual Request Request { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
