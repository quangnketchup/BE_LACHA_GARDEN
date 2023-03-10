using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using BussinessLayer.Dao;
using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using BussinessLayer.Repository;
using System.Collections;
using LachaGarden.Services;
using System.Text;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenPackageController : Controller
    {
        private readonly IGardenPackageRepository gardenPackageRepository;
        private readonly IPackageTypeRepository packageTypeRepository;

        public GardenPackageController(IGardenPackageRepository gardenPackageRepository)
        {
            this.gardenPackageRepository = gardenPackageRepository;
        }

        // GET: api/GardenPackage
        [HttpGet]
        public ActionResult<IEnumerable<GardenPackageDTO>> Get()
        {
            var gardenPackageList = gardenPackageRepository.GetGardenPackages();
            return Ok(gardenPackageList);
        }

        // GET: api/GardenPackage/5
        [HttpGet("{id}")]
        public ActionResult<GardenPackageDTO> Get(int id)
        {
            var gardenPackage = gardenPackageRepository.GetGardenPackageByID(id);
            if (gardenPackage == null)
            {
                return NotFound();
            }
            return Ok(gardenPackage);
        }

        // POST: api/GardenPackage/create
        [HttpPost("create")]
        public async Task<ActionResult> Post([FromBody] GardenPackageDTO gardenPackage)
        {
            if (ModelState.IsValid)
            {
                GardenPackage newGardenPackage = new GardenPackage
                {
                    NamePack = gardenPackage.NamePack,
                    Image = gardenPackage.Image,
                    Length = gardenPackage.Length,
                    Width = gardenPackage.Width,
                    Description = gardenPackage.Description,
                    Price = gardenPackage.Price,
                    Status = 1,
                    PackageTypeId = gardenPackage.PackageTypeId,
                };

                gardenPackageRepository.InsertGardenPackage(newGardenPackage);
                return CreatedAtAction(nameof(Get), new { id = newGardenPackage.Id }, newGardenPackage);
            }
            return BadRequest(ModelState);
        }


        // POST: api/GardenPackage/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Put(int id, [FromBody] GardenPackageDTO gardenPackage)
        {

            if (id != gardenPackage.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                GardenPackage updateGardenPackage = new GardenPackage
                {
                    Id = gardenPackage.Id,
                    NamePack = gardenPackage.NamePack,
                    Image = gardenPackage.Image,
                    Length = gardenPackage.Length,
                    Width = gardenPackage.Width,
                    Description = gardenPackage.Description,
                    Price = gardenPackage.Price,
                    Status = gardenPackage.Status,
                    PackageTypeId = gardenPackage.PackageTypeId
                };
                gardenPackageRepository.UpdateGardenPackage(updateGardenPackage);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        // POST: api/GardenPackage/delete/5
        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var gardenPackage = gardenPackageRepository.GetGardenPackageByID(id);
            if (gardenPackage == null)
            {
                return NotFound();
            }
            gardenPackageRepository.RemoveGardenPackage(id);
            return Ok("Delete successful");
        }

        // GET: api/GardenPackage/search?name=xyz
        [HttpGet("search")]
        public ActionResult<IEnumerable<GardenPackage>> Search(string name)
        {
            var gardenPackage = gardenPackageRepository.GetGardenPackages();
            var result = gardenPackage;

            if (name != null)
            {
                result = gardenPackage.Where(p => p.NamePack.ToLower().Contains(name.ToLower())).ToList();
            }

            return Ok(result);
        }
    }

}
