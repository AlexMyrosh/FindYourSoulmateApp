using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<MssqlContext>();

            var sqlConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MssqlContext>(options => options.UseSqlServer(sqlConnectionString));
        }
    }
}
