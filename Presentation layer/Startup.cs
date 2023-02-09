using AutoMapper;
using Business_Logic_Layer.AutoMapper;
using Business_Logic_Layer.Services;
using Business_Logic_Layer.Services.Interfaces;
using Data_Access_Layer.Context;
using Data_Access_Layer.Repositories;
using Data_Access_Layer.Repositories.Interfaces;
using Data_Access_Layer.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation_Layer.AutoMapper;

namespace Presentation_Layer
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
            var sqlConnectionString = Configuration.GetConnectionString("MSSQLConnectionString");
            services.AddDbContext<MssqlContext>(options => options.UseSqlServer(sqlConnectionString));

            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelsToEntityAutoMapper());
                mc.AddProfile(new ModelsToViewModelsAutoMapper());
            }).CreateMapper());

            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
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
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Survey}/{action=Index}/{id?}");
            });
        }
    }
}
