using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : Controller
    {
        private readonly ITreeRepository treeRepository;

        public TreeController(ITreeRepository treeRepository)
        {
            this.treeRepository = treeRepository;
        }

        // GET: api/Tree
        [HttpGet]
        public ActionResult<IEnumerable<GardenPackageDTO>> Get()
        {
            var treeList = treeRepository.GetTrees();
            return Ok(treeList);
        }

        // GET: api/Tree/5
        [HttpGet("{id}")]
        public ActionResult<TreeDTO> Get(int id)
        {
            var tree = treeRepository.GetTreeByID(id);
            if (tree == null)
            {
                return NotFound();
            }
            return Ok(tree);
        }

        // POST: api/Tree/create
        [HttpPost("create")]
        public ActionResult Post([FromBody] TreeDTO tree)
        {
            if (ModelState.IsValid)
            {
                Tree newTree = new Tree
                {
                    NameTree = tree.NameTree,
                    Image = tree.Image,
                    Price = tree.Price,
                    Description = tree.Description,
                    Status = tree.Status,
                    TreeTypeId = tree.TreeTypeId,
                    GardenPackageId = tree.GardenPackageId
                };

                treeRepository.InsertTree(newTree);
                return CreatedAtAction(nameof(Get), new { id = newTree.Id }, newTree);
            }
            return BadRequest(ModelState);
        }


        // POST: api/Tree/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Put(int id, [FromBody] TreeDTO tree)
        {

            if (id != tree.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Tree updateTree = new Tree
                {
                    Id = tree.Id,
                    Image = tree.Image,
                    Price = tree.Price,
                    Description = tree.Description,
                    Status = tree.Status,
                    TreeTypeId = tree.TreeTypeId,
                    GardenPackageId = tree.GardenPackageId
                };
                treeRepository.UpdateTree(updateTree);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // POST: api/Tree/delete/5
        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var tree = treeRepository.GetTreeByID(id);
            if (tree == null)
            {
                return NotFound();
            }
            treeRepository.RemoveTree(id);
            return Ok("Delete successful");
        }

        // GET: api/Tree/search?name=xyz
        [HttpGet("search")]
        public ActionResult<IEnumerable<Tree>> Search(string name)
        {
            var tree = treeRepository.GetTrees();
            var result = tree;

            if (name != null)
            {
                result = tree.Where(p => p.NameTree.ToLower().Contains(name.ToLower())).ToList();
            }

            return Ok(result);
        }
    }
}
