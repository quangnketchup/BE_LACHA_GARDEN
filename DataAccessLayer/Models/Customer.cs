using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public decimal? Phone { get; set; }
        public string Gmail { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
