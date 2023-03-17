using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using BussinessLayer.ViewModels;
using Castle.Core.Resource;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
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
            ArrayList RoomList = new ArrayList();
            IEnumerable<Room> room = roomViewModel.RoomRepository.GetRooms();
            Customer customer;
            Building building;
            foreach (Room rooms in room)
            {
                string customerID = (string)rooms.CustomerId;
                int buildingID = (int)rooms.BuildingId;
                customer = roomViewModel.customerRepository.GetCustomerByID(customerID);
                building = roomViewModel.BuildingRepository.GetBuildingByID(buildingID);
                if (customer != null || building != null)
                {
                    rooms.Customer = customer;
                    rooms.Building = building;
                    RoomList.Add(rooms);
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

        [HttpGet("search/{UserID}")]
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
    }
}