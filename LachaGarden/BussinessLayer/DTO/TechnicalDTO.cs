using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class TechnicalDTO
    {
        public int Id { get; set; }
        public string NameTech { get; set; }
        public string Gmail { get; set; }
        public decimal? Phone { get; set; }
        public string Image { get; set; }
        public int? Gender { get; set; }
        public int? Status { get; set; }
        public int? RoleId { get; set; }
    }
}
