using AutoMapper;
using Inter.Core.App.AutoMapper;
using Inter.Core.Infra.CrossCutting.IoCDeppendency;
using Inter.Core.Presentation.Configuration;
using Inter.Core.Presentation.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inter.Core.Presentation
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

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseMySql(
            //        Configuration.GetConnectionString("MySqlConnection")));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddDefaultUI(UIFramework.Bootstrap4)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddEntityFrameworkStores<ApplicationDbContext>();

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingsProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddDbContext<ContextDB>(options =>
            //       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<MySQLContext>(options =>
            //    options.UseMySql(Configuration.GetConnectionString("MySqlConnection")));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.ConfigureApplicationCookie(options =>
            {
                //options.LoginPath = "/Login";
                //options.ExpireTimeSpan = TimeSpan.FromSeconds(15);
            });

            BootStrapperIoC.RegisterServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //ContextSeedData.Seed(app.ApplicationServices).Wait();
        }
    }
}
