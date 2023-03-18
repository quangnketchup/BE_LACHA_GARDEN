using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class TreeCareDTO
    {
        public int Id { get; set; }
        public int? Status { get; set; }
        public string UserId { get; set; }
        public int? RequestId { get; set; }
    }
}