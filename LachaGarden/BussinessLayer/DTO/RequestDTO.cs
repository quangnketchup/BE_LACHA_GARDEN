using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public int? GardenId { get; set; }
    }
}