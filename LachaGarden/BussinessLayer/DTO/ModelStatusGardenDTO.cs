using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class ModelStatusGardenDTO
    {
        public int? Status { get; set; }

        public ModelStatusGardenDTO()
        {
        }

        public ModelStatusGardenDTO(int status)
        {
            this.Status = status;
        }
    }
}