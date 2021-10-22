using Rent.Shared.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Rent.Server.Data
{
    public class AppDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public AppDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Realty> Realties { get; set; }
        public DbSet<UserFeedback> UserFeedbacks { get; set; }
        public DbSet<RealtyFeedback> RealtyFeedbacks { get; set; }
    }
}

