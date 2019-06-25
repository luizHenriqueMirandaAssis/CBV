using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CBV.Core.Application.Interfaces.Handle;
using CBV.Infra.Data.EntityFramework.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CBV.Integration.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                #region Migrations

                try
                {
                    var context = scope.ServiceProvider.GetService<CBVContext>();
                    context.Database.Migrate();

                    var seedHandle = scope.ServiceProvider.GetService<ISeedHandle>();
                    seedHandle.Seed();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Não foi possível realizar a migração dos dados iniciais.");
                }

                #endregion

                #region Seed Spotify

                try
                {
                    var handle = scope.ServiceProvider.GetService<ISpotifyHandle>();
                    handle.InsertDiscs().GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Não foi possível consumir a API do Spotify para inserir os discos por cada gênero.");
                }

                #endregion
            }

            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
