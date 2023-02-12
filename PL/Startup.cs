using AutoMapper;
using BLL.AutoMapper;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Context;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PL.AutoMapper;
using PL.MiddleWares;
using Hangfire;

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

            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MssqlContext, MssqlContext>();

            services.AddTransient<UserIdCookiesMiddleware>();

            services.AddHangfire(x => x.UseSqlServerStorage(sqlConnectionString));
            services.AddHangfireServer();

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

            app.UseMiddleware<UserIdCookiesMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=User}/{action=Edit}/{surveyId=5012A854-5977-44FD-B915-C31DFF642242}");
            });
        }
    }
}
