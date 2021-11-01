using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Rent.Shared.Models;

namespace Rent.Server.Data.Configuration
{
	public class RealtyConfiguration : IEntityTypeConfiguration<Realty>
	{
		public void Configure(EntityTypeBuilder<Realty> builder)
		{
            // AppUser adm = new AppUser()  
            // {  
            //     Id = "b74ddd14-6340-4840-95c2-db12554843e5",  
            //     UserName = "Admin",  
            //     Email = "admin@email.com", 
            //     NormalizedUserName = "ADMIN@EMAIL.COM", 
            //     NormalizedEmail = "ADMIN@EMAIL.COM", 
            //     LockoutEnabled = true,  
            //     SecurityStamp = Guid.NewGuid().ToString()
            // };  

            // PasswordHasher<AppUser> phAdm = new PasswordHasher<AppUser>();
            // PasswordHasher<AppUser> phUser = new PasswordHasher<AppUser>();
            
            // adm.PasswordHash = phAdm.HashPassword(adm, "qwecxz");
  
            // builder.HasData(adm);  
		}
	}
}