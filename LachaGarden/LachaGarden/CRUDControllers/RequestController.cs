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
    public class RequestController : Controller
    {
        private readonly IRequestRepository requestRepository;
        private readonly RequestViewModel requestViewModel;

        public RequestController(IRequestRepository requestRepository, RequestViewModel requestViewModel)
        {
            this.requestRepository = requestRepository;
            this.requestViewModel = requestViewModel;
        }

        // GET: api/Request
        [HttpGet]
        public ActionResult<IEnumerable<RequestDTO>> Get()
        {
            var request = requestRepository.GetRequests();
            return Ok(request);
        }

        // GET: api/Request
        [HttpGet("search/GardenId")]
        public ActionResult<IEnumerable<RequestDTO>> GetByBuilding(int GardenID)
        {
            ArrayList RequestList = new ArrayList();
            var result = RequestList;
            IEnumerable<Request> requests = requestViewModel.RequestRepository.GetRequests();
            Garden garden;
            foreach (Request request in requests)
            {
                if (request.GardenId == GardenID)
                {
                    RequestList.Add(request);
                }
            }
            if (RequestList.Count == 0)
            {
                return BadRequest("NotFound");
            }
            return Ok(RequestList);
        }

        // GET: api/Request/5
        [HttpGet("{id}")]
        public ActionResult<RequestDTO> Get(int id)
        {
            var request = requestRepository.GetRequestByID(id);
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        // POST: api/Request/create
        [HttpPost("create")]
        public async Task<ActionResult> Post([FromBody] RequestDTO request)
        {
            var garden = requestViewModel.GardenRepository.GetGardenByID((int)request.GardenId);
            if (garden.Status != 2)
            {
                return BadRequest();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Request newRequest = new Request
                    {
                        Description = request.Description,
                        GardenId = request.GardenId,
                        Status = 1,
                    };

                    requestRepository.InsertRequest(newRequest);
                    return CreatedAtAction(nameof(Get), new { id = newRequest.Id }, newRequest);
                }
            }
            return BadRequest(ModelState);
        }

        // POST: api/Request/edit/5
        [HttpPut("edit/{id}")]
        public ActionResult Put(int id, [FromBody] RequestDTO request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                Request updateRequest = new Request
                {
                    Id = request.Id,
                    Description = request.Description,
                    GardenId = request.GardenId,
                    Status = request.Status,
                };
                requestRepository.UpdateRequest(updateRequest);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        [HttpPut("editStatus/{id}")]
        public ActionResult Put(int id, [FromBody] ModelStatusGardenDTO request)
        {
            if (ModelState.IsValid)
            {
                var checkRequest = requestRepository.GetRequestByID(id);
                Request updateRequest = new Request
                {
                    Id = checkRequest.Id,
                    Description = checkRequest.Description,
                    GardenId = checkRequest.GardenId,
                    Status = request.Status,
                };
                requestRepository.UpdateRequest(updateRequest);
                return Ok("Update Successfull");
            }
            return BadRequest(ModelState);
        }

        // POST: api/Request/delete/5
        [HttpPost("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var request = requestRepository.GetRequestByID(id);
            if (request == null)
            {
                return NotFound();
            }
            requestRepository.RemoveRequest(id);
            return Ok("Delete successful");
        }
    }
}