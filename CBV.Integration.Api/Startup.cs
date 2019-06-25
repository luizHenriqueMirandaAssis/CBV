using CBV.Core.Domain.Shared;
using CBV.Infra.CrossCutting.IoC;
using CBV.Infra.Data.EntityFramework.Context;
using CBV.Infra.Spotify.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CBV.Integration.Api
{
    public class Startup
    {
        private const string _appSettingsName = "AppSettings";
        private const string _spotifySettingsName = "SpotifySettings";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _appSettingsSection = Configuration.GetSection(_appSettingsName);
            _appSettings = _appSettingsSection.Get<AppSettings>();
        }

        private readonly IConfigurationSection _appSettingsSection;

        private readonly AppSettings _appSettings;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            RegisterServices(services);

            services.Configure<AppSettings>(_appSettingsSection);

            services.Configure<SpotifySettings>(Configuration.GetSection(_spotifySettingsName));

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<CBVContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CBVConnection")));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Cashback API", Version = "V1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeIoC.RegisterServices(services);
        }
    }
}
