using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Rent.Server.Data;
using Rent.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Rent.Server.Repositories
{
    public class AppUserRepository : AppRepository<AppUser>, IAppUserRepository
	{
		private readonly AppDbContext _dbContext;
		private readonly UserManager<AppUser> _userManager;

		public AppUserRepository(UserManager<AppUser> userManager, AppDbContext dbContext) : base(dbContext)
		{
			_userManager = userManager;
			_dbContext = dbContext;
		}

		public async Task<AppUser> GetUserById(string id)
		{
			return await _userManager.FindByIdAsync(id);
		}

		public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
			return await _userManager.Users.ToListAsync();
        }

		public Task<AppUser> GetUserRealties(string id)
		{
			var user = _dbContext.Users.Include(r => r.UserRealties).FirstOrDefaultAsync();
			return user;	
		}
	}
}
