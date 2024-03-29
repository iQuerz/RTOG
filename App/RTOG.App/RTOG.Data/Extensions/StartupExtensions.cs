﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RTOG.Data.Persistence;

namespace RTOG.Data.Extensions
{
    public class StartupExtensions
    {
        public static void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(
                    configuration.GetConnectionString("DBConnection")));
        }
    }
}
