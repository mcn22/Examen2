
using HotelFinalProgramacionAvanzada.DataAccess.Data;
using HotelFinalProgramacionAvanzada.DataAccess.Repositorio;
using HotelFinalProgramacionAvanzada.DataAccess.Repositorio.IRepositorio;
using HotelFinalProgramacionAvanzada.Resources;
using HotelFinalProgramacionAvanzada.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HotelFinalProgramacionAvanzada
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
            services.AddDbContext<ApplicationDbContext>
                (
                    options =>
                        options.UseSqlServer
                            (Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddScoped<IUnidadTrabajo, UnidadTrabajo>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.ConfigureApplicationCookie
              (
                options =>
                {
                    options.LoginPath = "/Identity/Account/Login";
                    options.LogoutPath = "/Identity/Account/Logout";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                }
              );

            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "496519634709007";
                options.AppSecret = "fcc2dc274927e17dde496aa9b0f41c6f";
            }
                         );


            services.AddAuthentication().AddGoogle(options =>
            {
                //IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
                options.ClientId = "789560180741-tiiblhpri19hmqm9489ndm7mrh29enpa.apps.googleusercontent.com";
                options.ClientSecret = "hScsz2X1IDJqV7ccP8SVTQe4";
            });


            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddSingleton<LocalizationService>();
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(ApplicationResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("ApplicationResource", assemblyName.Name);
                    };
                });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("es"),
                };
                options.DefaultRequestCulture = new RequestCulture("es");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.Configure<SendGridOptions>(Configuration.GetSection(SendGridOptions.Section));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            var requestlocalizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(requestlocalizationOptions.Value);

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });



        }
    }
}
