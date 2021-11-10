using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rent.Server.Data;
using Rent.Server.Repositories;
using Rent.Shared.Dto;
using Rent.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace Rent.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepository _repository;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AppUser> _logger;
        private readonly IMapper _mapper;

        private Task<AppUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public AppUserController(ILogger<AppUser> logger, IAppUserRepository repository, UserManager<AppUser> userManager, IMapper mapper, AppDbContext context)
        {
            _logger = logger;
            _repository = repository;
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
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
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById (string id)
        {
            var user = await _repository.GetUserById(id);
            _logger.LogInformation($"{DateTime.Now}: Get user Id {user.Id}");
            //return Ok(_mapper.Map<AppUserDto>(user));
            return Ok(user);
        }

        // GET: api/AppUsers/5/Realties
        [HttpGet("{id:guid}/realties")]
        public async Task<IActionResult> GetCurrentUserRealties(string id)
        {
            var user = await _context.Users.SingleAsync(u => u.Id == id); //Include(u => u.UserRealties).Where(u => u.Id == id).FirstOrDefaultAsync();
            _context.Entry(user).Collection(u => u.UserRealties).Load();
            //_logger.LogInformation($"{DateTime.Now}: Get user ID {user.Id} realities list");
            //return Ok(await _repository.GetUserRealties(currentUser.Id));
            return Ok(user);
        }

    }
}
