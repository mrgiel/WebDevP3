using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<GebruikerRepo>();
            
            services.AddRazorPages();
            
            //Mysql Versie
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            //DB connectie en identity gecombineerd 
            services.AddDbContext<AuthDbContext>(options => options.UseMySql(Configuration.GetConnectionString("AuthConnectionString"), serverVersion));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();

            //if authorized pages gets opened without being logged in we go to /login
            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Login";
            });

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(0);
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Users-Create", policy => policy.RequireClaim("Users-View"));
                options.AddPolicy("Users-View", policy => policy.RequireClaim("Users-View"));
                options.AddPolicy("Users-Details", policy => policy.RequireClaim("Users-Details"));
                options.AddPolicy("Users-Edit", policy => policy.RequireClaim("Users-Edit"));
                options.AddPolicy("Users-Delete", policy => policy.RequireClaim("Users-Delete"));
                options.AddPolicy("Roles-Create", policy => policy.RequireClaim("Roles-View"));
                options.AddPolicy("Roles-View", policy => policy.RequireClaim("Roles-View"));
                options.AddPolicy("Roles-Details", policy => policy.RequireClaim("Roles-Details"));
                options.AddPolicy("Roles-Edit", policy => policy.RequireClaim("Roles-Edit"));
                options.AddPolicy("Roles-Delete", policy => policy.RequireClaim("Roles-Delete"));
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            //New
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
