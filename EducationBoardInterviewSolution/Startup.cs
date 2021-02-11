using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using EducationBoardInterviewSolution.Data;
using EducationBoardInterviewSolution.Data.Entity;
using EducationBoardInterviewSolution.Services.Auth;
using EducationBoardInterviewSolution.Services.Auth.Interfaces;
using EducationBoardInterviewSolution.Services.AuthServices;
using EducationBoardInterviewSolution.Sevices.AuthServices.Interfaces;

namespace EducationBoardInterviewSolution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
                     
                         
            #region PDF DI
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            #endregion

            #region Database Settings
            services.AddDbContext<ATMDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ATMDbConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ATMDbContext>();
            #endregion
                       

            #region Auth Related Settings
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });           

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);

                options.LoginPath = "/Auth/Account/Login";
                options.AccessDeniedPath = "/Auth/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            #endregion

            #region Areas Config
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/areas/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/areas/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });
            #endregion

            #region Navbar
            services.AddScoped<INavbarService, NavbarService>();
            services.AddScoped<IUserInfoes, UserInfoesService>();
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => {
                    var resolver = options.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                });

            services.AddHttpContextAccessor();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromHours(24);
                options.Cookie.IsEssential = true;
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "controllers",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                     name: "areas",
                     template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");                
                
                routes.MapAreaRoute(
                    name: "default",
                    areaName: "Auth",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
