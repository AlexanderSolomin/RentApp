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
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Realty> Realties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1EA9FF62-ABAF-45BB-A629-4491E32D7F56",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "BCC0F9A0-6F84-4EBB-B40E-AFADB6DCF5D3",
                Name = "user",
                NormalizedName = "USER"
            });


            modelBuilder.Entity<City>().HasData(new City
            {
                Id = new Guid("800D7F2C-BF58-4BA4-A964-1CCFF6E6B6D9"),
                Name = "Санкт-Петербург"
            });

            modelBuilder.Entity<City>().HasData(new City
            {
                Id = new Guid("FE0BE5DF-6EF9-45A7-A7E4-00BF7E793ADC"),
                Name = "Москва"
            });

            modelBuilder.Entity<District>().HasData(new District
            {
                Id = new Guid("9C5D200C-FA1D-47F1-8590-66BCC36156D4"),
                Name = "Адмиралтейский"
            });

            modelBuilder.Entity<District>().HasData(new District
            {
                Id = new Guid("8017F8DD-49AE-4CF8-8AEF-69AA898F03B5"),
                Name = "Московский"
            });


            //modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            //{
            //    Id = "00CDE747-24E2-4378-8141-EA9D913E3239",
            //    UserName = "admin@email.com",
            //    ConcurrencyStamp = Guid.NewGuid().ToString(),
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    NormalizedUserName = "ADMIN",
            //    Email = "admin@email.com",
            //    NormalizedEmail = "ADMIN@EMAIL.COM",
            //    EmailConfirmed = true,
            //    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "P4$$word"),
            //});

            //modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            //{
            //    Id = "CAA30F75-33FE-4C83-9AB1-DCB2A900BCAC",
            //    UserName = "user@email.com",
            //    ConcurrencyStamp = Guid.NewGuid().ToString(),
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    NormalizedUserName = "USER",
            //    Email = "user@email.com",
            //    NormalizedEmail = "USER@EMAIL.COM",
            //    EmailConfirmed = true,
            //    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "P4$$word")

            //}); ;

            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = "1EA9FF62-ABAF-45BB-A629-4491E32D7F56",
            //    UserId = "00CDE747-24E2-4378-8141-EA9D913E3239"
            //});

            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = "BCC0F9A0-6F84-4EBB-B40E-AFADB6DCF5D3",
            //    UserId = "CAA30F75-33FE-4C83-9AB1-DCB2A900BCAC"
            //});



            //modelBuilder.Entity<Realty>().HasData(new Realty
            //{
            //    Id = new Guid("9F702F50-C806-4070-BC82-F2112323BBFA"),
            //    Title = "Меншиковский дворец",
            //    CreatedAt = DateTime.Now,
            //    Description = "Меншиковский дворец — построенный для приближенного императора Петра Первого, первого губернатора Санкт-Петербурга Александра Даниловича Меншикова, дворец выполнен в стиле петровского барокко, первое каменное здание Санкт-Петербурга.",
            //    BuildYear = 1710,
            //    Area = 2200,
            //    Rent = 10000000,
            //    Storeys = 3,
            //    Floor = 3,
            //    Rate = 5,
            //    Status = Status.RENTED,
            //    Category = Category.RESEDENTIAL,
            //    CityId = new Guid("800D7F2C-BF58-4BA4-A964-1CCFF6E6B6D9"),

            //    District = new District
            //    {
            //        Id = new Guid("9C5D200C-FA1D-47F1-8590-66BCC36156D4"),
            //        Name = "Адмиралтейский"
            //    },
            //    Owner = new ApplicationUser
            //    {
            //        Id = "CAA30F75-33FE-4C83-9AB1-DCB2A900BCAC",
            //        UserName = "User",
            //        NormalizedUserName = "USER",
            //        Email = "user@email.com",
            //        NormalizedEmail = "USER@EMAIL.COM",
            //        EmailConfirmed = true,
            //        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "P4$$word"),
            //        SecurityStamp = string.Empty
            //    },
            //    ImgPath = "./Images/1.jpg"
            //});

            //modelBuilder.Entity<Realty>().HasData(new Realty
            //{
            //    Id = new Guid("792157ED-AB54-4A76-8E2A-4D14B10D1F27"),
            //    Title = "Севкабель",
            //    CreatedAt = DateTime.Now,
            //    Description = "Дворец Юсуповых на Мойке — бывший дворец в Санкт-Петербурге, памятник истории и культуры федерального значения. Располагается на набережной реки Мойки, территория дворца с садом простирается до улицы Декабристов.",
            //    BuildYear = 1770,
            //    Area = 3200,
            //    Rent = 120000000,
            //    Storeys = 3,
            //    Floor = 3,
            //    Rate = 5,
            //    Status = Status.AVAILABLE,
            //    Category = Category.RESEDENTIAL,
            //    City = new City
            //    {
            //        Id = new Guid("800D7F2C-BF58-4BA4-A964-1CCFF6E6B6D9"),
            //        Name = "Санкт-Петербург"
            //    },
            //    District = new District
            //    {
            //        Id = new Guid("9C5D200C-FA1D-47F1-8590-66BCC36156D4"),
            //        Name = "Адмиралтейский"
            //    },
            //    Owner = new ApplicationUser
            //    {
            //        Id = "00CDE747-24E2-4378-8141-EA9D913E3239",
            //        UserName = "admin",
            //        NormalizedUserName = "ADMIN",
            //        Email = "admin@email.com",
            //        NormalizedEmail = "ADMIN@EMAIL.COM",
            //        EmailConfirmed = true,
            //        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "P4$$word"),
            //        SecurityStamp = string.Empty
            //    },
            //    ImgPath = "./Images/2.jpg"
            //});
        }
    }
}

