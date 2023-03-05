using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.IRepository
{
    public interface IAreaRepository
    {
        IEnumerable<Area> GetAreas();
        Area GetAreaByID(int AreaID);
        IEnumerable<Area> GetFiltered(string tag);
    }
}
