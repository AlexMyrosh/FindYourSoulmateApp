using AutoMapper;
using BLL.AutoMapper;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Context;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using PL.AutoMapper;

namespace PL
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
            var sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MssqlContext>(options => options.UseSqlServer(sqlConnectionString));

            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelsToEntityAutoMapper());
                mc.AddProfile(new ModelsToViewModelsAutoMapper());
            }).CreateMapper());

            // Services:
            services.AddScoped<IUserService, UserService>();

            // Repositories:
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MssqlContext, MssqlContext>();

            services.AddMvc();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
