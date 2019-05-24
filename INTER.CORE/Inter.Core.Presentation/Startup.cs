using Inter.Core.App.Application;
using Inter.Core.App.AutoMapper;
using Inter.Core.App.Intefaces;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using Inter.Core.Domain.Service;
using Inter.Core.Domain.ServiceInterface;
using Inter.Core.Infra.Data.Context;
using Inter.Core.Infra.Data.Repositories;
using Inter.Core.Presentation.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var mapperConfiguration = new AutoMapper.MapperConfiguration(config =>
            {
                config.AddProfile(new MappingsProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ContextDB>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            InjectorDependency(services);

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
        }

        private void InjectorDependency(IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepository<>), typeof(RepositoryBase<>));

            services.AddTransient<IStudentAppService, StudentAppService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddTransient<IEnvironmentAppService, EnvironmentAppService>();
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IEnvironmentRepository, EnvironmentRepository>();

            services.AddTransient<ICollegeAppService, CollegeAppService>();
            services.AddTransient<ICollegeService, CollegeService>();
            services.AddTransient<ICollegeRepository, CollegeRepository>();

            services.AddTransient<IAccomodationAppService, AccomodationAppService>();
            services.AddTransient<IAccomodationService, AccomodationService>();
            services.AddTransient<IAccomodationRepository, AccomodationRepository>();

        }
    }
}
