using System.Linq;
using System.Threading.Tasks;
using Ejc.Auth.Repository.Interfaces;
using Ejc.Services;
using Ejc.Services.Interfaces;
using Ejc.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ejc.Auth
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton(_ => Configuration);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<Entities.AppSettings>(appSettingsSection);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    IUserRepository userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();

                    if (!userRepo.GetAll().Any())
                    {
                        userRepo.Create(new Entities.User() { Email = "viniciusmpg@gmail.com", Password = "123", Name = "Vinicius" });
                        userRepo.Create(new Entities.User() { Email = "renatompg@gmail.com", Password = "123", Name = "Renato" });
                    }
                }
                
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Users}/{action=GetUsers}/{id?}");
            });
        }
    }
}
