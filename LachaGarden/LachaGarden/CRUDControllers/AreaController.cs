using Abp.AspNetCore.Mvc.Authorization;
using Abp.Authorization;
using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly IAreaRepository areaRepository;

        public AreaController(IAreaRepository areaRepository)
        {
            this.areaRepository = areaRepository;
        }

        // GET: api/Area
        [HttpGet, Authorize]
        public ActionResult<IEnumerable<AreaDTO>> Get()
        {
            var areaList = areaRepository.GetAreas();
            return Ok(areaList);
        }

        // GET: api/Area/5
        [HttpGet("{id}")]
        public ActionResult<AreaDTO> Get(int id)
        {
            var area = areaRepository.GetAreaByID(id);
            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        // GET: api/Area/search?name=xyz
        [HttpGet("search")]
        public ActionResult<IEnumerable<Area>> Search(string AreaNumber)
        {
            var area = areaRepository.GetAreas();
            var result = area;

            if (AreaNumber != null)
            {
                var searchString = AreaNumber.ToString();
                result = area.ToList();
            }

            return Ok(result);
        }
    }
}