using BussinessLayer.Dao;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;

namespace BussinessLayer.Repository
{
    public class RoomRepository : IRoomRepository
    {
        public IEnumerable<Room> GetFiltered(string tag) => RoomDao.Instance.GetFilteredRoom(tag);

        public Room GetRoomByID(int RoomID) => RoomDao.Instance.GetRoomByID(RoomID);

        public IEnumerable<Room> GetRooms() => RoomDao.Instance.getRoomList(); public void InsertPackageType(PackageType packageType) => PackageTypeDao.Instance.addNewPackageType(packageType);

        public void InsertRoom(Room room) => RoomDao.Instance.addNewRoom(room);

        public void RemoveRoom(int RoomId) => RoomDao.Instance.Remove(RoomId);

        public void UpdateRoom(Room room) => RoomDao.Instance.Update(room);
    }
}