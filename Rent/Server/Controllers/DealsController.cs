using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent.Server.Data;
using Rent.Shared.Models;

namespace Rent.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private readonly IAppRepository<Deal> _repository;

        public DealsController(IAppRepository<Deal> repository)
        {
            this._repository = repository;
        }
        // GET: 
        [HttpGet]
        public async Task<ActionResult> GetDeals(int skip = 0, int take = 5, string orderBy = "Name")
        {
            try
            {
                return Ok(await _repository.List(skip, take, orderBy));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriving data from server");
            }
        }

        // GET: 
        [HttpGet("{name}")]
        public async Task<ActionResult> GetDealByName(string name)
        {
            try
            {
                return Ok(await _repository.GetByName(name));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriving data from server");
            }
        }

        // POST: 
        [HttpPost]
        public async Task<ActionResult<Deal>> AddDeal(Deal deal)
        {
            try
            {
                if (deal == null)
                {
                    return BadRequest();
                }
                var nameExists = await _repository.GetByName(deal.Name);
                if (nameExists != null)
                {
                    ModelState.AddModelError("Name", "Name exist");
                    return BadRequest(ModelState);
                }
                var addedDeal = await _repository.Add(deal);
                return CreatedAtAction(nameof(GetDeals),
                     new { id = Guid.NewGuid().ToString() }, addedDeal);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error adding to DB");
            }
        }

        // PUT:
        [HttpPut("{name}")]
        public async Task<ActionResult<Deal>> PutDeal(string name, Deal deal)
        {
            try
            {
                if (name != deal.Name)
                {
                    return BadRequest("Name mismatch");
                }
                var dealToUpdate = await _repository.GetByName(name);
                if (dealToUpdate == null)
                {
                    return NotFound($"Deal with name {name} not found");
                }
                await _repository.Edit(deal);
                return await _repository.GetByName(name);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating deal");
            }
        }

        // DELETE:
        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteDeal(string name)
        {
            try
            {
                var dealToDelete = await _repository.GetByName(name);
                if (dealToDelete == null)
                {
                    return NotFound($"Deal with name {name} not found");
                }
                await _repository.Delete(dealToDelete);
                return Ok($"Deal with name {name} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting deal");
            }
        }
    }
}
