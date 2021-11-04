using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent.Server.Repositories;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Rent.Server.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RealtiesController : ControllerBase
    {
        private readonly IRealtyRepository _repository;
        private readonly ILogger<Realty> _logger;
        public RealtiesController(ILogger<Realty> logger, IRealtyRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        
        // GET: 
        [HttpGet]
        public async Task<ActionResult> GetRealties([FromQuery] PagingParameters pagingParameters)
        {
            try
            {
                var result = await _repository.GetRealties(pagingParameters);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
                _logger.LogInformation($"{DateTime.Now}: Queried realties");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: Error occured while getAllParametred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retriving data from server: {ex.Message}");
            }
        }

        // GET: 
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetRealtyById(Guid id)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now}: Getting realty by ID");
                return Ok(await _repository.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: Error occured while getById: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retriving data from server: {ex.Message}");
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
       
                await _repository.Add(realty);
                _logger.LogInformation($"{DateTime.Now}: At {typeof(Realty).Name} New realty GUID {realty.Id} added");
                return CreatedAtAction(nameof(GetRealties), realty);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: Error occured while add to DB: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding to DB: {ex.Message}");
            }
        }

        // PUT:
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Realty>> PutRealty(Guid id, [FromBody]Realty realty)
        {
            try
            {
                if (id != realty.Id)
                {
                    return BadRequest("Id mismatch");
                }
                var realtyToUpdate = await _repository.GetById(id);
                if (realtyToUpdate == null)
                {
                    return NotFound($"Realty with ID {id} not found");
                }
                
                await _repository.Edit(id, realty);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: Error occuried while put: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating realty: {ex.Message}");
            }
        }

        // DELETE:
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteRealty(Guid id)
        {
            try
            {
                var realtyToDelete = await _repository.GetById(id);
                if (realtyToDelete == null)
                {
                    return NotFound($"Realty with ID {id} not found");
                }
                await _repository.Delete(realtyToDelete);
                _logger.LogInformation($"{DateTime.Now}: Realty with GUID {realtyToDelete.Id} deleted");
                return Ok($"Realty with Id {id} deleted");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: Error occuried while delete: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error deleting realty: {ex.Message}");
            }
        }
    }
}

