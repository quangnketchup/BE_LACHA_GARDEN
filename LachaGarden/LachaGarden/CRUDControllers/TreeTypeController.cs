using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeTypeController : Controller
    {
        private readonly ITreeTypeRepository treeTypeRepository;

        public TreeTypeController(ITreeTypeRepository treeTypeRepository)
        {
            this.treeTypeRepository = treeTypeRepository;
        }

        // GET: api/TreeType
        [HttpGet]
        public ActionResult<IEnumerable<TreeTypeDTO>> Get()
        {
            var treeTypeList = treeTypeRepository.GetTreeTypes();
            return Ok(treeTypeList);
        }

        // GET: api/TreeType/5
        [HttpGet("{id}")]
        public ActionResult<TreeTypeDTO> Get(int id)
        {
            var treeType = treeTypeRepository.GetTreeTypeByID(id);
            if (treeType == null)
            {
                return NotFound();
            }
            return Ok(treeType);
        }

        // POST: api/TreeType/create
        [HttpPost("create")]
        public ActionResult Post([FromBody] TreeTypeDTO treeType)
        {
            if (ModelState.IsValid)
            {
                TreeType newTreeType = new TreeType
                {
                    NameTreeType = treeType.NameTreeType,
                    Status = 1,
                };

                treeTypeRepository.InsertTreeType(newTreeType);
                return CreatedAtAction(nameof(Get), new { id = newTreeType.Id }, newTreeType);
            }
            return BadRequest(ModelState);
        }

        // POST: api/TreeType/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Put(int id, [FromBody] TreeTypeDTO treeType)
        {
            if (id != treeType.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                TreeType UpdateTreeType = new TreeType
                {
                    Id = treeType.Id,
                    NameTreeType = treeType.NameTreeType,
                    Status = 1,
                };
                treeTypeRepository.UpdateTreeType(UpdateTreeType);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        // POST: api/TreeType/delete/5
        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var treeType = treeTypeRepository.GetTreeTypeByID(id);
            if (treeType == null)
            {
                return NotFound();
            }
            treeTypeRepository.RemoveTreeType(id);
            return Ok("Delete successful");
        }

        // GET: api/TreeType/search?name=xyz
        [HttpGet("search")]
        public ActionResult<IEnumerable<TreeType>> Search(string name)
        {
            var treeType = treeTypeRepository.GetTreeTypes();
            var result = treeType;

            if (name != null)
            {
                result = treeType.Where(p => p.NameTreeType.ToLower().Contains(name.ToLower())).ToList();
            }

            return Ok(result);
        }
    }
}