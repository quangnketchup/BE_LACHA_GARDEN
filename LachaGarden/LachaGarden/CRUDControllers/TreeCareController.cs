using BussinessLayer.DTO;
using BussinessLayer.IRepository;
using BussinessLayer.Repository;
using BussinessLayer.ViewModels;
using DataAccessLayer.Models;
using LachaGarden.Models.Mail;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeCareController : Controller
    {
        private TreeCareViewModel treeCareViewModel;

        public TreeCareController(TreeCareViewModel treeCareViewModel)
        {
            this.treeCareViewModel = treeCareViewModel;
        }

        // GET: api/TreeCare
        [HttpGet]
        public ActionResult<IEnumerable<TreeCareDTO>> Get()
        {
            var request = treeCareViewModel._treeCareRepository.GetTreeCares();
            return Ok(request);
        }

        // GET: api/TreeCare
        [HttpGet("search/RequestID")]
        public ActionResult<IEnumerable<TreeCareDTO>> GetByRequest(int requestID)
        {
            ArrayList treeCareList = new ArrayList();
            var result = treeCareList;
            IEnumerable<TreeCare> treeCares = treeCareViewModel._treeCareRepository.GetTreeCares();
            foreach (TreeCare treeCare in treeCares)
            {
                if (treeCare.RequestId == requestID)
                {
                    result.Add(treeCare);
                }
            }
            if (result.Count == 0)
            {
                return BadRequest("NotFound");
            }
            return Ok(result);
        }

        // GET: api/TreeCare
        [HttpGet("search/UserID")]
        public ActionResult<IEnumerable<UserDTO>> GetByUser(string userID)
        {
            ArrayList treeCareList = new ArrayList();
            var result = treeCareList;
            IEnumerable<TreeCare> treeCares = treeCareViewModel._treeCareRepository.GetTreeCares();
            foreach (TreeCare treeCare in treeCares)
            {
                if (treeCare.UserId == userID)
                {
                    result.Add(treeCare);
                }
            }
            if (result.Count == 0)
            {
                return BadRequest("NotFound");
            }
            return Ok(result);
        }

        // GET: api/TreeCare/5
        [HttpGet("{id}")]
        public ActionResult<TreeCareDTO> Get(int id)
        {
            var treeCare = treeCareViewModel._treeCareRepository.GetTreeCareByID(id);
            if (treeCare == null)
            {
                return NotFound();
            }
            return Ok(treeCare);
        }

        // POST: api/TreeCare/create
        [HttpPost("create")]
        public async Task<ActionResult> Post([FromBody] TreeCareDTO treeCare)
        {
            if (ModelState.IsValid)
            {
                TreeCare newTreeCare = new TreeCare
                {
                    UserId = treeCare.UserId,
                    RequestId = treeCare.RequestId,
                    Status = 2,
                };
                Request request = treeCareViewModel._requestRepository.GetRequestByID((int)newTreeCare.RequestId);
                if (request.Status != 2)
                {
                    request.Status = 2;
                    treeCareViewModel._requestRepository.UpdateRequest(request);
                }
                treeCareViewModel._treeCareRepository.InsertTreeCare(newTreeCare);
                return CreatedAtAction(nameof(Get), new { id = newTreeCare.Id }, newTreeCare);
            }
            return BadRequest(ModelState);
        }

        // POST: api/TreeCare/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Put(int id, [FromBody] TreeCareDTO treeCare)
        {
            if (id != treeCare.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                TreeCare updateTreeCare = new TreeCare
                {
                    Id = treeCare.Id,
                    UserId = treeCare.UserId,
                    RequestId = treeCare.RequestId,
                    Status = treeCare.Status,
                };
                treeCareViewModel._treeCareRepository.UpdateTreeCare(updateTreeCare);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        // POST: api/TreeCare/edit/5
        [HttpPut("editStatus/{id}")]
        public ActionResult Put(int id, [FromBody] ModelStatusGardenDTO treeCare)
        {
            var treeCareUpdate = treeCareViewModel._treeCareRepository.GetTreeCareByID(id);
            if (treeCareUpdate.Status == 3)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                TreeCare UpdateTreeCare = new TreeCare
                {
                    Id = id,
                    RequestId = treeCareUpdate.RequestId,
                    UserId = treeCareUpdate.UserId,
                    Status = treeCare.Status,
                };

                //-------------------------

                treeCareViewModel._treeCareRepository.UpdateTreeCare(UpdateTreeCare);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        // POST: api/TreeCare/delete/5
        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var treeCare = treeCareViewModel._treeCareRepository.GetTreeCareByID(id);
            if (treeCare == null)
            {
                return NotFound();
            }
            treeCareViewModel._treeCareRepository.RemoveTreeCare(id);
            return Ok("Delete successful");
        }
    }
}