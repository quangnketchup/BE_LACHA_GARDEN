using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using BussinessLayer.Repository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : Controller
    {

        private readonly IBuildingRepository buildingRepository;

        public BuildingController(IBuildingRepository buildingRepository)
        {
            this.buildingRepository = buildingRepository;
        }

        // GET: api/Building
        [HttpGet]
        public ActionResult<IEnumerable<BuildingDTO>> Get()
        {
            var buildingList = buildingRepository.GetBuildings();
            return Ok(buildingList);
        }

        // GET: api/Building/5
        [HttpGet("{id}")]
        public ActionResult<BuildingDTO> Get(int id)
        {
            var building = buildingRepository.GetBuildingByID(id);
            if (building == null)
            {
                return NotFound();
            }
            return Ok(building);
        }

        // GET: api/Building/search?name=xyz
        [HttpGet("search")]
        public ActionResult<IEnumerable<Building>> Search(string BuildingNumber)
        {
            var building = buildingRepository.GetBuildings();
            var result = building;

            if (BuildingNumber != null)
            {
                var searchString = BuildingNumber.ToString();
                result = building.ToList();
            }

            return Ok(result);
        }
    }
}
