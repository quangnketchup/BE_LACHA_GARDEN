using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class ResultDTO
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime DateReport { get; set; }
        public int Status { get; set; }
        public int? TreeCareId { get; set; }
    }
}