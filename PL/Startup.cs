using BLL.AutoMapper;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Context;
using DAL.Extensions;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
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
            ServiceConfiguration.ConfigureServices(services, Configuration);

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new ModelsToEntityAutoMapper());
                config.AddProfile(new ModelsToViewModelsAutoMapper());
            }, typeof(Startup));

            // Services:
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInterestService, InterestService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IContactService, ContactService>();

            // Repositories:
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInterestRepository, InterestRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MssqlContext, MssqlContext>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(7);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddMvc();
            services.AddRazorPages();
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
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
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
