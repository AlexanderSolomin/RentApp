using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

            AppUser user1 = new AppUser()  
            {  
                Id = "bb6f8d03-d22b-4773-8b50-5236aee43af5",  
                UserName = "user1@email.com",  
                Email = "user1@email.com",  
                NormalizedUserName = "USER1@EMAIL.COM", 
                NormalizedEmail = "USER1@EMAIL.COM", 
                LockoutEnabled = true,  
                SecurityStamp = Guid.NewGuid().ToString()
            }; 
            AppUser user2 = new AppUser()  
            {  
                Id = "94f37fd7-5e95-4f28-a41b-6c9e760d774c",  
                UserName = "user2@email.com",  
                Email = "user2@email.com",  
                NormalizedUserName = "USER2@EMAIL.COM", 
                NormalizedEmail = "USER2@EMAIL.COM", 
                LockoutEnabled = true,  
                SecurityStamp = Guid.NewGuid().ToString()
            }; 
            AppUser user3 = new AppUser()  
            {  
                Id = "ec50b448-0776-4ee3-9671-d13d5495045f",  
                UserName = "user3@email.com",  
                Email = "user3@email.com",  
                NormalizedUserName = "USER3@EMAIL.COM", 
                NormalizedEmail = "USER3@EMAIL.COM", 
                LockoutEnabled = true,  
                SecurityStamp = Guid.NewGuid().ToString()
            }; 

            PasswordHasher<AppUser> phAdm = new PasswordHasher<AppUser>();
            PasswordHasher<AppUser> phUser = new PasswordHasher<AppUser>();
            PasswordHasher<AppUser> phUser1 = new PasswordHasher<AppUser>();
            PasswordHasher<AppUser> phUser2 = new PasswordHasher<AppUser>();
            PasswordHasher<AppUser> phUser3 = new PasswordHasher<AppUser>();

            adm.PasswordHash = phAdm.HashPassword(adm, "qwecxz");
            user.PasswordHash = phUser.HashPassword(user, "cxzewq");
            user.PasswordHash = phUser1.HashPassword(user, "cxzewq");
            user.PasswordHash = phUser2.HashPassword(user, "cxzewq");
            user.PasswordHash = phUser3.HashPassword(user, "cxzewq");

            builder.HasData(adm);  
            builder.HasData(user);  
            builder.HasData(user1);  
            builder.HasData(user2);  
            builder.HasData(user3);  


            // builder.OwnsOne(r => r.Realties).HasData(
            //     new Realty { Owner = adm, CreatedAt = DateTime.Now.AddDays(-300), Description = "Строение 1 описание", BuildYear = 1995,
            //     Area = 33, Rent = 30000, Storeys = 5, Floor = 3, Rate = 0, Status = 0, Category = 0, City = new City(), 
            //     Feedbacks = new List<RealtyFeedback> {
            //         new RealtyFeedback { Text = "Feedback 1", CreatedAt = DateTime.Now.AddDays(-250), SenderUser = user, Rate = 4},
            //         new RealtyFeedback { Text = "Feedback 2", CreatedAt = DateTime.Now.AddDays(-230), SenderUser = user1, Rate = 2},
            //         new RealtyFeedback { Text = "Feedback 3", CreatedAt = DateTime.Now.AddDays(-200), SenderUser = user2, Rate = 5},
            //         new RealtyFeedback { Text = "Feedback 4", CreatedAt = DateTime.Now.AddDays(-180), SenderUser = user3, Rate = 4},
            //     }, 
            //     Deals = new List<Deal> {
            //         new Deal { StartDate = DateTime.Now.AddDays(-280), EndDate = DateTime.Now.AddDays(-250), RentPerMonth = 30000, 
            //             Owner = adm, Tenant = user, Realty = , Feedbacks = }
            //     },
            //     ImgPath = "", IsActive = true
            // });
		}
	}
}