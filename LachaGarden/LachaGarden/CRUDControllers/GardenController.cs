using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenController : Controller
    {
        private readonly IGardenRepository gardenRepository;

        public GardenController(IGardenRepository gardenRepository)
        {
            this.gardenRepository = gardenRepository;
        }

        // GET: api/Garden
        [HttpGet]
        public ActionResult<IEnumerable<GardenDTO>> Get()
        {
            var gardenList = gardenRepository.GetGardens();
            return Ok(gardenList);
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