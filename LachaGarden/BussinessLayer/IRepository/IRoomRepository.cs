using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.IRepository
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetRooms();
        Room GetRoomByID(int roomID);
        IEnumerable<Room> GetFiltered(string tag);
    }
}
