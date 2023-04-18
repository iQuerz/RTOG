using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RTOG.Business.Interfaces;
using RTOG.Business.Services;

namespace RTOG.Business.Extensions
{
    public class StartupExtensions
    {
        public static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
        {
            Data.Extensions.StartupExtensions.ConfigureServices(services, configuration);

            //business services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILobbyService, LobbyService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IMapService, MapService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUpgradeService, UpgradeService>();

            services.AddScoped<IColorsService, ColorsService>();
            services.AddScoped<IFactionService, FactionService>();
        }
    }
}
