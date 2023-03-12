using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageTypeController : Controller
    {
        private readonly IPackageTypeRepository packageTypeRepository;

        public PackageTypeController(IPackageTypeRepository packageTypeRepository)
        {
            this.packageTypeRepository = packageTypeRepository;
        }

        // GET: api/PackageType
        [HttpGet]
        public ActionResult<IEnumerable<PackageTypeDTO>> Get()
        {
            var packageTypeList = packageTypeRepository.GetPackageTypes();
            return Ok(packageTypeList);
        }

        // GET: api/PackageType/5
        [HttpGet("{id}")]
        public ActionResult<PackageTypeDTO> Get(int id)
        {
            var packageType = packageTypeRepository.GetPackageTypeByID(id);
            if (packageType == null)
            {
                return NotFound();
            }
            return Ok(packageType);
        }

        // POST: api/PackageType/create
        [HttpPost("create")]
        public ActionResult Post([FromBody] PackageTypeDTO packageType)
        {
            if (ModelState.IsValid)
            {
                PackageType newPackageType = new PackageType
                {
                    NamePackageType = packageType.NamePackageType,
                    Status = 1,
                };

                packageTypeRepository.InsertPackageType(newPackageType);
                return CreatedAtAction(nameof(Get), new { id = newPackageType.Id }, newPackageType);
            }
            return BadRequest(ModelState);
        }

        // POST: api/PackageType/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Put(int id, [FromBody] PackageTypeDTO packageType)
        {
            if (id != packageType.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                PackageType UpdatePackageType = new PackageType
                {
                    Id = packageType.Id,
                    NamePackageType = packageType.NamePackageType,
                    Status = 1,
                };
                packageTypeRepository.UpdatePackageType(UpdatePackageType);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        // POST: api/PackageType/delete/5
        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var packageType = packageTypeRepository.GetPackageTypeByID(id);
            if (packageType == null)
            {
                return NotFound();
            }
            packageTypeRepository.RemovePackageType(id);
            return Ok("Delete successful");
        }

        // GET: api/PackageType/search?name=xyz
        [HttpGet("search")]
        public ActionResult<IEnumerable<PackageType>> Search(string name)
        {
            var packageType = packageTypeRepository.GetPackageTypes();
            var result = packageType;

            if (name != null)
            {
                result = packageType.Where(p => p.NamePackageType.ToLower().Contains(name.ToLower())).ToList();
            }

            return Ok(result);
        }
    }
}