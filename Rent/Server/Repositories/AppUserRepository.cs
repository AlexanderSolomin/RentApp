using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Rent.Server.Data;
using Rent.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Rent.Server.Repositories
{
    public class AppUserRepository : IAppUserRepository
	{
		//private readonly AppDbContext _dbContext;
		private readonly UserManager<AppUser> _userManager;

		public AppUserRepository(UserManager<AppUser> userManager) //: base(dbContext)
		{
			_userManager = userManager;
		}
		public async Task<AppUser> GetUserById(string id)
		{
			return await _userManager.FindByIdAsync(id);//_dbContext.Users.FindAsync(id);
		}
		public async Task<IEnumerable<AppUser>> GetAllUsers()
        {
			return await _userManager.Users.ToListAsync();
        }

	}
}
