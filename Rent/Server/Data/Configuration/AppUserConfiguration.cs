using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Rent.Shared.Models;

namespace Rent.Server.Data.Configuration
{
	public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
            AppUser adm = new AppUser()  
            {  
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",  
                UserName = "Admin",  
                Email = "admin@email.com", 
                NormalizedUserName = "ADMIN@EMAIL.COM", 
                NormalizedEmail = "ADMIN@EMAIL.COM", 
                LockoutEnabled = true,  
                SecurityStamp = Guid.NewGuid().ToString()
            };  
            AppUser user = new AppUser()  
            {  
                Id = "5f2c82e4-13c7-443a-b63d-7b92030fb09f",  
                UserName = "user@email.com",  
                Email = "user@email.com",  
                NormalizedUserName = "USER@EMAIL.COM", 
                NormalizedEmail = "USER@EMAIL.COM", 
                LockoutEnabled = true,  
                SecurityStamp = Guid.NewGuid().ToString()
            };  

            PasswordHasher<AppUser> phAdm = new PasswordHasher<AppUser>();
            PasswordHasher<AppUser> phUser = new PasswordHasher<AppUser>();
            
            adm.PasswordHash = phAdm.HashPassword(adm, "qwecxz");
            user.PasswordHash = phUser.HashPassword(user, "cxzewq");
  
            builder.HasData(adm);  
            builder.HasData(user);  
		}
	}
}