using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class GardenAndGardenPackage
    {
        private Garden garden { get; set; }
        private GardenPackage gardenPackage { get; set; }

        public GardenAndGardenPackage(Garden garden, GardenPackage gardenPackage)
        {
            this.garden = garden;
            this.gardenPackage = gardenPackage;
        }
    }
}