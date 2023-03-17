using DataAccessLayer.Models;

namespace BussinessLayer.Dao
{
    public class RoomDao
    {
        //-----------------------
        private lachagardenContext db = new lachagardenContext();

        private static RoomDao instance = null;
        private static readonly object instanceLock = new object();

        private RoomDao()
        {
        }

        public static RoomDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomDao();
                    }
                    return instance;
                }
            }
        }

        //-----------------------

        public IEnumerable<Room> getRoomList()
        {
            var rooms = new List<Room>();
            List<Room> FList = new List<Room>();
            try
            {
                using var context = new lachagardenContext();
                rooms = context.Rooms.ToList();
                for (int i = 1; i <= rooms.Count; i++)
                {
                    if (rooms[i - 1].Status == 1) { FList.Add(rooms[i - 1]); }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return FList;
        }

        //-----------------------
        public Room GetRoomByID(int RoomID)
        {
            Room room = null;
            try
            {
                using var context = new lachagardenContext();
                room = context.Rooms.SingleOrDefault(p => p.Id == RoomID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return room;
        }

        //-----------------------
        public async void checkRoomNumber(Room room)
        {
            var roomList = getRoomList();
            foreach (Room RoomNumber in roomList)
            {
                if (RoomNumber.RoomNumber == room.RoomNumber)
                {
                    throw new Exception("The roomNumber is already exist.");
                }
            }
        }

        //----------------------
        public void addNewRoom(Room room)
        {
            try
            {
                Room rooms = GetRoomByID(room.Id);
                checkRoomNumber(room);
                if (rooms == null)
                {
                    using var context = new lachagardenContext();
                    context.Rooms.Add(room);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The room is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-----------------------
        public void Update(Room room)
        {
            try
            {
                checkRoomNumber(room);
                Room rooms = GetRoomByID(room.Id);
                if (rooms != null)
                {
                    using var context = new lachagardenContext();
                    context.Rooms.Update(room);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The room does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //-------------------------

        public void Remove(int roomId)
        {
            try
            {
                Room rooms = GetRoomByID(roomId);
                if (rooms != null)
                {
                    using (lachagardenContext db = new lachagardenContext())
                    {
                        Room room = db.Rooms.Where(d => d.Id == roomId).First();
                        room.Status = 0;
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The room does not already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Room> GetFilteredRoom(string tag)
        {
            List<Room> filtered = new List<Room>();
            foreach (Room room in getRoomList())
            {
                int add = 0;
                if (room.Id.ToString().Contains(tag))
                    add = 1;
                if (add == 1)
                    filtered.Add(room);
            }
            return filtered;
        }
    }
}