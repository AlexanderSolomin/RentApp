using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent.Server.Data;
using Rent.Shared.Models;
using Microsoft.Extensions.Logging;

namespace Rent.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IAppRepository<City> _repository;
        private readonly ILogger<City> _logger;
        public CitiesController(ILogger<City> logger, IAppRepository<City> repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        
        // GET: 
        [HttpGet]
        public async Task<ActionResult> GetCities(int skip = 0, int take = 5, string orderBy = "Title")
        {
            try
            {
                return Ok(await _repository.List(skip, take, orderBy));
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: At {typeof(City).Name} Error occured while getAllParametred: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retriving data from server: {ex.Message}");
            }
        }

        // GET: 
        [HttpGet("{name}")]
        public async Task<ActionResult> GetCityByTitle(string title)
        {
            try
            {
                return Ok(await _repository.GetByTitle(title));

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: At {typeof(City).Name} Error occured while getByName: {ex.Message}");
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
                var nameExists = await _repository.GetByTitle(city.Title);
                if (nameExists != null)
                {
                    ModelState.AddModelError("Title", "Title exists");
                    return BadRequest(ModelState);
                }
                var addedCity = await _repository.Add(city);
                _logger.LogInformation($"{DateTime.Now}: At {typeof(City).Name} New city GUID {city.Id} added");
                return CreatedAtAction(nameof(GetCities), addedCity);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: At {typeof(City).Name} Error occured while add to DB: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding to DB: {ex.Message}");
            }
        }

        // PUT:
        [HttpPut("{title}")]
        public async Task<ActionResult<City>> PutCity(string title, City city)
        {
            try
            {
                if (title != city.Title)
                {
                    return BadRequest("Name mismatch");
                }
                var cityToUpdate = await _repository.GetByTitle(title);
                if (cityToUpdate == null)
                {
                    return NotFound($"City with name {title} not found");
                }
                
                return Ok(await _repository.Edit(city));
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: At {typeof(City).Name} Error occuried while put: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating city: {ex.Message}");
            }
        }


        // DELETE:
        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteCity(string name)
        {
            try
            {
                var cityToDelete = await _repository.GetByTitle(name);
                if (cityToDelete == null)
                {
                    return NotFound($"City with name {name} not found");
                }
                await _repository.Delete(cityToDelete);
                _logger.LogInformation($"{DateTime.Now}: At {typeof(City).Name} City with GUID {cityToDelete.Id} deleted");
                return Ok($"City with name {name} deleted");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"{DateTime.Now}: At {typeof(City).Name} Error occuried while delete: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error deleting city: {ex.Message}");
            }
        }
    }
}
