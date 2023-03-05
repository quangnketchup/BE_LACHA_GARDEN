using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class PackageTypeDTO
    {
        public int Id { get; set; }
        public string NamePackageType { get; set; }
        public int? Status { get; set; }
    }
}
