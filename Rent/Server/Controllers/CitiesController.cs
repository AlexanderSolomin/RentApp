using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent.Server.Data;
using Rent.Shared.Models;

namespace Rent.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IAppRepository<City> _repository;

        public CitiesController(IAppRepository<City> repository)
        {
            this._repository = repository;
        }
        // GET: 
        [HttpGet]
        public async Task<ActionResult> GetCities(int skip = 0, int take = 5, string orderBy = "Name")
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
        public async Task<ActionResult> GetCityByName(string name)
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
        public async Task<ActionResult<City>> AddCity(City city)
        {
            try
            {
                if (city == null)
                {
                    return BadRequest();
                }
                var nameExists = await _repository.GetByName(city.Name);
                if (nameExists != null)
                {
                    ModelState.AddModelError("Name", "Name exist");
                    return BadRequest(ModelState);
                }
                var addedCity = await _repository.Add(city);
                return CreatedAtAction(nameof(GetCities),
                     new { id = Guid.NewGuid().ToString() }, addedCity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error adding to DB");
            }
        }

        // PUT:
        [HttpPut("{name}")]
        public async Task<ActionResult<City>> PutCity(string name, City city)
        {
            try
            {
                if (name != city.Name)
                {
                    return BadRequest("Name mismatch");
                }
                var cityToUpdate = await _repository.GetByName(name);
                if (cityToUpdate == null)
                {
                    return NotFound($"City with name {name} not found");
                }
                
                return Ok(await _repository.Edit(city));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating city");
            }
        }


        // DELETE:
        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteCity(string name)
        {
            try
            {
                var cityToDelete = await _repository.GetByName(name);
                if (cityToDelete == null)
                {
                    return NotFound($"City with name {name} not found");
                }
                await _repository.Delete(cityToDelete);
                return Ok($"City with name {name} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting city");
            }
        }
    }
}
