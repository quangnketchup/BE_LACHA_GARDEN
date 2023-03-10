using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.IRepository
{
    public interface IGardenRepository
    {
        IEnumerable<Garden> GetGardens();
        Garden GetGardenByID(int GardenID);
        IEnumerable<Garden> GetFiltered(string tag);
        void InsertGarden(Garden garden);
        void UpdateGarden(Garden garden);
        void RemoveGarden(int gardenId);
    }
}
