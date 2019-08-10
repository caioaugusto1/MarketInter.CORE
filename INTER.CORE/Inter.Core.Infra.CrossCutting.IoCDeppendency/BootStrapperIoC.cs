using Inter.Core.App.Application;
using Inter.Core.App.Intefaces;
using Inter.Core.App.Intefaces.Identity;
using Inter.Core.App.ViewModel.Identity;
using Inter.Core.Domain.Entities;
using Inter.Core.Domain.Interfaces.Repositories;
using Inter.Core.Domain.Interfaces.Services;
using Inter.Core.Domain.Service;
using Inter.Core.Infra.Data.Context;
using Inter.Core.Infra.Data.Repositories;
using Inter.Core.Infra.Data.Repositories.Base;
using Inter.Core.Infra.Data.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inter.Core.Infra.CrossCutting.IoCDeppendency
{
    public static class BootStrapperIoC
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MySQLContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("MySqlConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<MySQLContext>();

            services.AddSingleton(typeof(IRepository<>), typeof(RepositoryBase<>));

            services.AddTransient<IApplicationUserAppService, ApplicationUserAppService>();

            services.AddTransient<IStudentAppService, StudentAppService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IStudentRepository, StudentRepository>();

            services.AddTransient<IEnvironmentAppService, EnvironmentAppService>();
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IEnvironmentRepository, EnvironmentRepository>();

            services.AddTransient<ICollegeAppService, CollegeAppService>();
            services.AddTransient<ICollegeService, CollegeService>();
            services.AddTransient<ICollegeRepository, CollegeRepository>();

            services.AddTransient<ICollegeTimeAppService, CollegeTimeAppService>();
            services.AddTransient<ICollegeTimeService, CollegeTimeService>();
            services.AddTransient<ICollegeTimeRepository, CollegeTimeRepository>();

            services.AddTransient<IAccomodationAppService, AccomodationAppService>();
            services.AddTransient<IAccomodationService, AccomodationService>();
            services.AddTransient<IAccomodationRepository, AccomodationRepository>();

            services.AddTransient<ICulturalExchangeAppService, CulturalExchangeAppService>();
            services.AddTransient<ICulturalExchangeService, CulturalExchangeService>();
            services.AddTransient<ICulturalExchangeRepository, CulturalExchangeRepository>();

            services.AddTransient<ICulturalExchangeFileUploadAppService, CulturalExchangeFileUploadAppService>();
            services.AddTransient<ICulturalExchangeFileUploadService, CulturalExchangeFileUploadService>();
            services.AddTransient<ICulturalExchangeFileUploadRepository, CulturalExchangeFileUploadRepository>();

            services.AddTransient<IReceivePaymentCulturalExchangeAppService, ReceivePaymentCulturalExchangeAppService>();
            services.AddTransient<IReceivePaymentCulturalExchangeService, ReceivePaymentCulturalExchangeService>();
            services.AddTransient<IReceivePaymentCulturalExchangeRepository, ReceivePaymentCulturalExchangeRepository>();

            services.AddTransient<IReceivePaymentCulturalExchangeAppService, ReceivePaymentCulturalExchangeAppService>();
            services.AddTransient<IReceivePaymentCulturalExchangeService, ReceivePaymentCulturalExchangeService>();
            services.AddTransient<IReceivePaymentCulturalExchangeRepository, ReceivePaymentCulturalExchangeRepository>();

            services.AddTransient<IPaymentCulturalExchangeAppService, PaymentCulturalExchangeAppService>();
            services.AddTransient<IPaymentCulturalExchangeService, PaymentCulturalExchangeService>();
            services.AddTransient<IPaymentCulturalExchangeRepository, PaymentCulturalExchangeRepository>();

            services.AddTransient<IFileUploadAppService, FileUploadAppService>();
            services.AddTransient<IFileUploadService, FileUploadService>();

            //services.AddSingleton<IConnectationFactory, DefaultConnectionFactory>();
        }
    }
}
