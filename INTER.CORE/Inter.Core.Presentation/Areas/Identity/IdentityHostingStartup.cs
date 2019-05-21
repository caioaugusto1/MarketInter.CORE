using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Inter.Core.Presentation.Areas.Identity.IdentityHostingStartup))]
namespace Inter.Core.Presentation.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}