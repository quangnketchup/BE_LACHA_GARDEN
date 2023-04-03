using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalController : Controller
    {
        private readonly IUserRepository technicalRepository;

        public TechnicalController(IUserRepository technicalRepository)
        {
            this.technicalRepository = technicalRepository;
        }

        // GET: api/Technical

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            var technicalList = technicalRepository.GetTechnicals();
            return Ok(technicalList);
        }

        // GET: api/Technical/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(string id)
        {
            var technical = technicalRepository.GetUserByID(id);
            if (technical == null)
            {
                return NotFound();
            }
            return Ok(technical);
        }
    }
}