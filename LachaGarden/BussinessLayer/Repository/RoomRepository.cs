using BussinessLayer.Dao;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public IEnumerable<Room> GetFiltered(string tag) => RoomDao.Instance.GetFilteredRoom(tag);

        public Room GetRoomByID(int RoomID) => RoomDao.Instance.GetRoomByID(RoomID);

        public IEnumerable<Room> GetRooms() => RoomDao.Instance.getRoomList();
    }
}
