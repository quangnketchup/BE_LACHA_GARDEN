using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomRepository roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        // GET: api/Room
        [HttpGet]
        public ActionResult<IEnumerable<RoomDTO>> Get()
        {
            var roomList = roomRepository.GetRooms();
            return Ok(roomList);
        }

        // GET: api/Room/5
        [HttpGet("{id}")]
        public ActionResult<RoomDTO> Get(int id)
        {
            var room = roomRepository.GetRoomByID(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        // GET: api/Room/search?name=xyz
        [HttpGet("search")]
        public ActionResult<IEnumerable<Room>> Search(string RoomNumber)
        {
            var room = roomRepository.GetRooms();
            var result = room;

            if (RoomNumber != null)
            {
                var searchString = RoomNumber.ToString();
                result = room.ToList();
            }

            return Ok(result);
        }
    }
}
