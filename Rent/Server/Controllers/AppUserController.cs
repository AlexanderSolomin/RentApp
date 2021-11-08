using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rent.Server.Repositories;
using Rent.Shared.Dto;
using Rent.Shared.Models;

namespace Rent.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserRepository _repository;
        private readonly ILogger<AppUser> _logger;
        private readonly IMapper _mapper;


        public AppUsersController(ILogger<AppUser> logger, IAppUserRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/AppUsers/
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repository.GetAllUsers();
            //return Ok(_mapper.Map<IEnumerable<AppUserDto>>(users));
            return Ok(users);
        }

        // GET: api/AppUsers/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetUserById (string id)
        {
            var user = await _repository.GetUserById(id);
            _logger.LogInformation($"{DateTime.Now}: Get user Id {user.Id}");
            //return Ok(_mapper.Map<AppUserDto>(user));
            return Ok(user);
        }


    }
}
