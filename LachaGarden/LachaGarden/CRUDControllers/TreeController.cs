using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using BussinessLayer.ViewModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : Controller
    {
        private readonly ITreeRepository treeRepository;
        private readonly TreeViewModel treeViewModel;

        public TreeController(ITreeRepository treeRepository, TreeViewModel treeViewModel)
        {
            this.treeRepository = treeRepository;
            this.treeViewModel = treeViewModel;
        }

        // GET: api/Tree
        [HttpGet]
        public ActionResult<IEnumerable<TreeDTO>> Get()
        {
            ArrayList TreeList = new ArrayList();
            IEnumerable<Tree> tree = treeViewModel.treeRepository.GetTrees();
            TreeType treeType;
            foreach (Tree trees in tree)
            {
                int treeID = (int)trees.TreeTypeId;
                treeType = treeViewModel.treeTypeRepository.GetTreeTypeByID(treeID);
                if (treeType != null)
                {
                    trees.TreeType = treeType;
                    TreeList.Add(trees);
                }
            }
            return Ok(TreeList);
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
                    NameTree = tree.NameTree,
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