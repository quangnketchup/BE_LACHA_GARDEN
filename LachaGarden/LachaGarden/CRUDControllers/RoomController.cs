using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using BussinessLayer.Repository;
using BussinessLayer.ViewModels;
using Castle.Core.Resource;
using DataAccessLayer.Models;
using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Libuv.Internal;
using System.Collections;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomRepository roomRepository;
        private readonly RoomViewModel roomViewModel;

        public RoomController(IRoomRepository roomRepository, RoomViewModel roomViewModel)
        {
            this.roomRepository = roomRepository;
            this.roomViewModel = roomViewModel;
        }

        // GET: api/Room
        [HttpGet]
        public ActionResult<IEnumerable<RoomDTO>> Get()
        {
            var room = roomRepository.GetRooms();
            return Ok(room);
        }

        //Get: api/Room/Search/{UserID}
        [HttpGet("search/UserID")]
        public ActionResult<IEnumerable<Room>> SearchRoomByUserID(string UserID)
        {
            ArrayList ListUser = new ArrayList();
            IEnumerable<Room> rooms = roomViewModel.RoomRepository.GetRooms();
            Customer customer;
            foreach (Room room in rooms)
            {
                string customerID = (string)room.CustomerId;
                customer = roomViewModel.customerRepository.GetCustomerByID(UserID);
                if (customer.Id == room.CustomerId)
                {
                    ListUser.Add(room);
                }
            }

            return Ok(ListUser);
        }

        // GET: api/Room
        [HttpGet("search/BuildingID")]
        public ActionResult<IEnumerable<RoomDTO>> GetByBuilding(int BuildingID)
        {
            ArrayList RoomList = new ArrayList();
            IEnumerable<Room> rooms = roomViewModel.RoomRepository.GetRooms();
            Building building;
            foreach (Room room in rooms)
            {
                int BuildingId = (int)room.BuildingId;
                building = roomViewModel.BuildingRepository.GetBuildingByID(BuildingId);
                if (building.Id == room.BuildingId)
                {
                    RoomList.Add(room);
                }
            }
            return Ok(RoomList);
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

        // POST: api/Room/create
        [HttpPost("create")]
        public async Task<ActionResult> Post([FromBody] RoomDTO room)
        {
            if (ModelState.IsValid)
            {
                Room newRoom = new Room
                {
                    RoomNumber = room.RoomNumber,
                    Length = room.Length,
                    Width = room.Width,
                    BuildingId = room.BuildingId,
                    CustomerId = room.CustomerId,
                    Status = 1,
                };

                roomRepository.InsertRoom(newRoom);
                return CreatedAtAction(nameof(Get), new { id = newRoom.Id }, newRoom);
            }
            return BadRequest(ModelState);
        }

        // POST: api/Room/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Put(int id, [FromBody] RoomDTO room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Room updateRoom = new Room
                {
                    Id = room.Id,
                    RoomNumber = room.RoomNumber,
                    Length = room.Length,
                    Width = room.Width,
                    BuildingId = room.BuildingId,
                    CustomerId = room.CustomerId,
                    Status = 1,
                };
                roomRepository.UpdateRoom(updateRoom);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        // POST: api/Room/delete/5
        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var room = roomRepository.GetRoomByID(id);
            if (room == null)
            {
                return NotFound();
            }
            roomRepository.RemoveRoom(id);
            return Ok("Delete successful");
        }
    }
}