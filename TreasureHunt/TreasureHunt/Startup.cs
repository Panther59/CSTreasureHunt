using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using TreasureHunt.Common;
using TreasureHunt.Data;
using TreasureHunt.Services;

namespace TreasureHunt
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors();
			services.AddControllersWithViews();

			this.AddServiceDependencies(services);

			// In production, the Angular files will be served from this  directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});
		}

		private void AddServiceDependencies(IServiceCollection services)
		{
			var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("AppSettings:TokenIssuerKey"));
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});
			var connection = Configuration.GetConnectionString("TreasureHuntDBConnectionString");
			services.AddDbContext<TreasureHuntDBContext>(o => o.UseSqlServer(connection));

			services.AddHttpContextAccessor();

			services.AddScoped<Common.ISession, Session>();
			services.AddScoped<IMapper, Mapper>();
			services.AddScoped<IQuizzesService, QuizzesService>();
			services.AddScoped<IUsersService, UsersService>();
			services.AddScoped<IResultService, ResultService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseRouting();

			app.UseCors(
				options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
			);

			app.UseAuthentication();
			app.UseAuthorization();
			app.UseMiddleware<ErrorHandlingMiddleware>();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			//app.UseSpa(spa =>
			//{
			//	// To learn more about options for serving an Angular SPA from ASP.NET Core,
			//	// see https://go.microsoft.com/fwlink/?linkid=864501

			//	spa.Options.SourcePath = "ClientApp";

			//	if (env.IsDevelopment())
			//	{
			//		spa.UseAngularCliServer(npmScript: "start");
			//	}
			//});
		}
	}
}
