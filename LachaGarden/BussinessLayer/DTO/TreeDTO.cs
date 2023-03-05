using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class TreeDTO
    {
        public int Id { get; set; }
        public string NameTree { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double? Price { get; set; }
        public int? Status { get; set; }
        public int? TreeTypeId { get; set; }
        public int? GardenPackageId { get; set; }
    }
}
