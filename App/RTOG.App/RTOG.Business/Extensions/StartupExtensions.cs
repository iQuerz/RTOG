using Microsoft.Extensions.DependencyInjection;

namespace RTOG.Business.Extensions
{
    public class StartupExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Data.Extensions.StartupExtensions.ConfigureServices(services);

            //business services
            //services.AddScoped<IService, Service>();
        }
    }
}
