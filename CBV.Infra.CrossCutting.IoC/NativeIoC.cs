using CBV.Core.Application.Interfaces.Handle;
using CBV.Core.Application.Interfaces.Repositories;
using CBV.Core.Application.Interfaces.Services;
using CBV.Core.Application.Services;
using CBV.Infra.Data.EntityFramework.Repository;
using CBV.Infra.Data.Seed;
using CBV.Infra.Http.Handle;
using CBV.Infra.Json.Handle;
using CBV.Infra.Spotify.Handle;
using Microsoft.Extensions.DependencyInjection;

namespace CBV.Infra.CrossCutting.IoC
{
    public class NativeIoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Handle
            services.AddScoped<ISpotifyHandle, SpotifyHandle>();
            services.AddScoped<IJsonHandle, JsonHandle>();
            services.AddScoped<IHttpHandle, HttpHandle>();
            services.AddScoped<ISeedHandle, SeedHandle>();

            //Repository
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<ICashbackRepository, CashbackRepository>();
            services.AddScoped<IDiaSemanaRepository, DiaSemanaRepository>();
            services.AddScoped<IDiscoRepository, DiscoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            //Application service
            services.AddScoped<ICatalogoAppService, CatalogoAppService>();
            services.AddScoped<IVendaAppService, VendaAppService>();
        }
    }
}
