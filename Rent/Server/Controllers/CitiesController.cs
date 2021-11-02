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
    // [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _repository;
        private readonly ILogger<City> _logger;
        public CitiesController(ILogger<City> logger, ICityRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        
        // GET: 
        [HttpGet]
        public async Task<ActionResult> GetCities([FromQuery] PagingParameters pagingParameters)
        {
            try
            {
                var result = await _repository.GetAllCities(pagingParameters);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
                _logger.LogInformation($"{DateTime.Now}: Queried all the cities");
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
        [HttpGet("{title}")]
        public async Task<ActionResult> GetCityByTitle(string title)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now}: Getting city by title");
                return Ok(await _repository.GetCityByTitle(title));

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: Error occured while getByTitle: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retriving data from server: {ex.Message}");
            }
        }

        // GET: 
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetCityById(Guid id)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now}: Getting city by ID");
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
        public async Task<ActionResult<City>> AddCity(City city)
        {
            try
            {
                if (city == null)
                {
                    return BadRequest();
                }
                var nameExists = await _repository.GetCityByTitle(city.Title);
                if (nameExists != null)
                {
                    ModelState.AddModelError("Title", "Title exists");
                    return BadRequest(ModelState);
                }
                await _repository.Add(city);
                _logger.LogInformation($"{DateTime.Now}: At {typeof(City).Name} New city GUID {city.Id} added");
                return CreatedAtAction(nameof(GetCities), city);
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
        public async Task<ActionResult<City>> PutCity(Guid id, City city)
        {
            try
            {
                if (id != city.Id)
                {
                    return BadRequest("Id mismatch");
                }
                var cityToUpdate = await _repository.GetById(id);
                if (cityToUpdate == null)
                {
                    return NotFound($"City with ID {id} not found");
                }
                
                await _repository.Edit(city);
                return Ok(await _repository.GetById(city.Id));
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: Error occuried while put: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating city: {ex.Message}");
            }
        }

        // DELETE:
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteCity(Guid id)
        {
            try
            {
                var cityToDelete = await _repository.GetById(id);
                if (cityToDelete == null)
                {
                    return NotFound($"City with ID {id} not found");
                }
                await _repository.Delete(cityToDelete);
                _logger.LogInformation($"{DateTime.Now}: City with GUID {cityToDelete.Id} deleted");
                return Ok($"City with Id {id} deleted");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: Error occuried while delete: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error deleting city: {ex.Message}");
            }
        }
    }
}
