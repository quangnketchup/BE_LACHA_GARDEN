using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class GardenDTO
    {
        public int Id { get; set; }
        public int? Status { get; set; }
        public int? GardenPackageId { get; set; }

        public DateTime? DateTime { get; set; }
        public int? RoomId { get; set; }
    }
}
