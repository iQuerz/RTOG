using Microsoft.Extensions.DependencyInjection;
using RTOG.Business.Interfaces;
using RTOG.Business.Services;

namespace RTOG.Business.Extensions
{
    public class StartupExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Data.Extensions.StartupExtensions.ConfigureServices(services);

            //business services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILobbyService, LobbyService>();
            services.AddScoped<IGameService, GameService>();

        }
    }
}
