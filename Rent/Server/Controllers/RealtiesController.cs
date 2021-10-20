using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent.Server.Data;
using Rent.Shared.Models;

namespace Rent.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealtiesController : ControllerBase
    {
        private readonly IAppRepository<Realty> _repository;

        public RealtiesController(IAppRepository<Realty> repository)
        {
            this._repository = repository;
        }
        // GET: api/Realties
        [HttpGet]
        public async Task<ActionResult> GetRealties(int skip = 0, int take = 5)
        {
            try
            {
                return Ok(await _repository.List(skip, take));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ошибка при получении данных из базы");
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetRealtyByName(string name)
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
        public async Task<ActionResult<Realty>> AddRealty(Realty realty)
        {
            try
            {
                if (realty == null)
                {
                    return BadRequest();
                }
                var nameExists = await _repository.GetByName(realty.Name);
                if (nameExists != null)
                {
                    ModelState.AddModelError("Name", "Name exist");
                    return BadRequest(ModelState);
                }
                var addedRealty = await _repository.Add(realty);
                return CreatedAtAction(nameof(GetRealties),
                     new { id = Guid.NewGuid().ToString() }, addedRealty);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error adding to DB");
            }
        }

        // PUT:
        [HttpPut("{name}")]
        public async Task<ActionResult<Realty>> PutRealty(string name, Realty realty)
        {
            try
            {
                if (name != realty.Name)
                {
                    return BadRequest("Name mismatch");
                }
                var realtyToUpdate = await _repository.GetByName(name);
                if (realtyToUpdate == null)
                {
                    return NotFound($"Realty with name {name} not found");
                }
                return await _repository.Edit(realtyToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating city");
            }
        }


        // DELETE: api/City/5
        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteRealty(string name)
        {
            try
            {
                var realtyToDelete = await _repository.GetByName(name);
                if (realtyToDelete == null)
                {
                    return NotFound($"Realty with name {name} not found");
                }
                await _repository.Delete(realtyToDelete);
                return Ok($"Realty with name {name} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting realty");
            }
        }
    }
}
