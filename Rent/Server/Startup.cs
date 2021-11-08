using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.FileProviders;
using Rent.Server.Data;
using Rent.Server.Repositories;
using Rent.Shared.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Features;
using System.IO;
using Microsoft.OpenApi.Models;


namespace Rent.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlite(
					Configuration.GetConnectionString("DefaultConnection"))
					.EnableSensitiveDataLogging());

			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddDefaultIdentity<AppUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
			})
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>();

			services.AddIdentityServer()
				.AddApiAuthorization<AppUser, AppDbContext>();

			services.AddAuthentication()
				.AddIdentityServerJwt();

			services.AddAutoMapper(typeof(Startup));
			services.AddScoped(typeof(IAppRepository<>), typeof(AppRepository<>));
			services.AddScoped<ICityRepository, CityRepository>();
			services.AddScoped<IRealtyRepository, RealtyRepository>();
			services.AddScoped<IAppUserRepository, AppUserRepository>();


			services.AddCors(policy =>
					{
						policy.AddPolicy("CorsPolicy", opt => opt
						.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod()
						.WithExposedHeaders("X-Pagination"));
					});

			services.Configure<FormOptions>(o =>
			{
				o.ValueLengthLimit = int.MaxValue;
				o.MultipartBodyLengthLimit = int.MaxValue;
				o.MemoryBufferThreshold = int.MaxValue;
			});

			services.AddControllersWithViews();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "RentApp", Version = "v1" });
			});

			services.AddRazorPages();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
				app.UseWebAssemblyDebugging();
				logger.LogInformation("In Development.");
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
				logger.LogInformation("Not Development.");
			}

			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions()
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
				RequestPath = new PathString("/StaticFiles")
			});

			app.UseRouting();

			app.UseIdentityServer();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentApp V1");
			});
		}
	}
}
