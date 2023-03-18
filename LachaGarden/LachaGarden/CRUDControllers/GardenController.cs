using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using BussinessLayer.ViewModels;
using Castle.MicroKernel;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenController : Controller
    {
        private readonly IGardenRepository gardenRepository;
        private readonly IGardenPackageRepository gardenPackageRepository;
        private readonly GardenViewModel gardenAndGardenPackageRepository;
        private readonly ICustomerRepository customerRepository;

        public GardenController(ICustomerRepository customerRepository, IGardenRepository gardenRepository, IGardenPackageRepository gardenPackageRepository, GardenViewModel gardenAndGardenPackageRepository)
        {
            this.gardenRepository = gardenRepository;
            this.customerRepository = customerRepository;
            this.gardenPackageRepository = gardenPackageRepository;
            this.gardenAndGardenPackageRepository = gardenAndGardenPackageRepository;
        }

        // GET: api/Garden/CustomerID
        [HttpGet("CustomerID")]
        public ActionResult<IEnumerable<GardenDTO>> Get(string CustomerID)
        {
            //Get ListRoomByCustomerID
            var roomCus = gardenAndGardenPackageRepository.RoomRepository.GetRooms();
            ArrayList ListGarden = new ArrayList();
            var gardens = gardenRepository.GetGardens();
            foreach (Room roomToAdd in roomCus)
            {
                if (roomToAdd.CustomerId == CustomerID)
                {
                    foreach (Garden garden in gardens)
                    {
                        if (garden.RoomId == roomToAdd.Id)
                        {
                            ListGarden.Add(garden);
                        }
                    }
                }
            }

            return Ok(ListGarden);
        }

        // GET: api/Garden
        [HttpGet]
        public ActionResult<IEnumerable<GardenDTO>> Get()
        {
            ArrayList order = new ArrayList();
            IEnumerable<Garden> garden = gardenAndGardenPackageRepository.GardenRepository.GetGardens();
            GardenPackage gardenPack;
            Room room;
            foreach (Garden gardenList in garden)
            {
                int gardenPackID = (int)gardenList.GardenPackageId;
                int roomID = (int)gardenList.RoomId;
                gardenPack = gardenAndGardenPackageRepository.GardenPackageRepository.GetGardenPackageByID(gardenPackID);
                room = gardenAndGardenPackageRepository.RoomRepository.GetRoomByID(roomID);
                if (gardenPack != null || room != null)
                {
                    gardenList.GardenPackage = gardenPack;
                    gardenList.Room = room;
                    order.Add(gardenList);
                }
            }
            return Ok(order);
        }

        // GET: api/Garden/5
        [HttpGet("{id}"), AutoValidateAntiforgeryToken]
        public ActionResult<GardenDTO> Get(int id)
        {
            var garden = gardenRepository.GetGardenByID(id);
            if (garden == null)
            {
                return NotFound();
            }
            return Ok(garden);
        }

        // POST: api/Garden/create
        [HttpPost("create")]
        public ActionResult Post([FromBody] GardenDTO garden)
        {
            if (ModelState.IsValid)
            {
                Garden newGarden = new Garden
                {
                    Status = 1,
                    DateTime = garden.DateTime,
                    GardenPackageId = garden.GardenPackageId,
                    RoomId = garden.RoomId,
                };

                gardenRepository.InsertGarden(newGarden);
                return CreatedAtAction(nameof(Get), new { id = newGarden.Id }, newGarden);
            }
            return BadRequest(ModelState);
        }

        // POST: api/Garden/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Put(int id, [FromBody] GardenDTO garden)
        {
            if (id != garden.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Garden UpdateGarden = new Garden
                {
                    Id = garden.Id,
                    DateTime = garden.DateTime,
                    GardenPackageId = garden.GardenPackageId,
                    Status = garden.Status,
                    RoomId = garden.RoomId,
                };
                gardenRepository.UpdateGarden(UpdateGarden);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        // POST: api/Garden/delete/5
        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var garden = gardenRepository.GetGardenByID(id);
            //var garden = gardenRepository.GetGar
            if (garden == null)
            {
                return NotFound();
            }
            gardenRepository.RemoveGarden(id);
            return Ok("Delete successful");
        }

        // GET: api/Garden/search?name=xyz
        [HttpGet("search")]
        public ActionResult<IEnumerable<Garden>> Search(string GardenNumber)
        {
            var garden = gardenRepository.GetGardens();
            var result = garden;

            if (GardenNumber != null)
            {
                var searchString = GardenNumber.ToString();
                result = garden.ToList();
            }

            return Ok(result);
        }
    }
}