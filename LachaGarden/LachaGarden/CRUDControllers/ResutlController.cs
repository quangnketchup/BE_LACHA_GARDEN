using BussinessLayer.DTO;
using BussinessLayer.ViewModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace LachaGarden.CRUDControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResutlController : Controller
    {
        private ResultViewModels resultViewModel;

        public ResutlController(ResultViewModels resultViewModel)
        {
            this.resultViewModel = resultViewModel;
        }

        // GET: api/Result
        [HttpGet]
        public ActionResult<IEnumerable<ResultDTO>> Get()
        {
            var request = resultViewModel._resultRepository.GetResults();
            return Ok(request);
        }

        // GET: api/Result
        [HttpGet("search/TreeCareID")]
        public ActionResult<IEnumerable<UserDTO>> GetByUser(int TreeCareID)
        {
            ArrayList resultList = new ArrayList();
            var resultResponse = resultList;
            IEnumerable<Result> results = resultViewModel._resultRepository.GetResults();
            foreach (Result result in results)
            {
                if (result.TreeCareId == TreeCareID)
                {
                    resultResponse.Add(result);
                }
            }
            if (resultResponse.Count == 0)
            {
                return BadRequest("NotFound");
            }
            return Ok(resultResponse);
        }

        // GET: api/Result/5
        [HttpGet("{id}")]
        public ActionResult<ResultDTO> Get(int id)
        {
            var result = resultViewModel._resultRepository.GetResultByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/Result/create
        [HttpPost("create")]
        public async Task<ActionResult> Post([FromBody] ResultDTO result)
        {
            if (ModelState.IsValid)
            {
                Result newResult = new Result
                {
                    Image = result.Image,
                    Description = result.Description,
                    DateReport = result.DateReport,
                    TreeCareId = result.TreeCareId,
                    Status = 1,
                };

                resultViewModel._resultRepository.InsertResult(newResult);
                return CreatedAtAction(nameof(Get), new { id = newResult.Id }, newResult);
            }
            return BadRequest(ModelState);
        }

        // POST: api/Result/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Put(int id, [FromBody] ResultDTO result)
        {
            if (id != result.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Result updateResult = new Result
                {
                    Id = result.Id,
                    Image = result.Image,
                    Description = result.Description,
                    DateReport = result.DateReport,
                    TreeCareId = result.TreeCareId,
                    Status = result.Status,
                };
                resultViewModel._resultRepository.UpdateResult(updateResult);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        // POST: api/Result/delete/5
        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var result = resultViewModel._resultRepository.GetResultByID(id);
            if (result == null)
            {
                return NotFound();
            }
            resultViewModel._resultRepository.RemoveResult(id);
            return Ok("Delete successful");
        }
    }
}