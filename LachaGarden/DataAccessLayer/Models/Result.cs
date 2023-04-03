using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime DateReport { get; set; }
        public int Status { get; set; }
        public int? TreeCareId { get; set; }

        public virtual TreeCare TreeCare { get; set; }
    }
}
