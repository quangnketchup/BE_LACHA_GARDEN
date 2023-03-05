using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class BuildingDTO
    {
        public int Id { get; set; }
        public string NameBuilding { get; set; }
        public int? AreaId { get; set; }
    }
}
