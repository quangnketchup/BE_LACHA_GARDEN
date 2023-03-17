using DataAccessLayer.Models;

namespace BussinessLayer.IRepository
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetRooms();

        Room GetRoomByID(int roomID);

        IEnumerable<Room> GetFiltered(string tag);

        void InsertRoom(Room room);

        void UpdateRoom(Room room);

        void RemoveRoom(int RoomId);
    }
}