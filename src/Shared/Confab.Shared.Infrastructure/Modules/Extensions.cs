using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.IO;

namespace Confab.Shared.Infrastructure.Modules
{
    internal static class Extensions
    {
        internal static IHostBuilder ConfigureModules(this IHostBuilder hostBuilder)
            => hostBuilder.ConfigureAppConfiguration((ctx, cft) =>
            {
                foreach (var settings in GetSettings("*"))
                {
                    cft.AddJsonFile(settings);
                }

                foreach (var settings in GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}"))
                {
                    cft.AddJsonFile(settings);
                }

                IEnumerable<string> GetSettings(string pattern)
                    => Directory.EnumerateFiles(ctx.HostingEnvironment.ContentRootPath, searchPattern: 
                        $"module.{pattern}.json", SearchOption.AllDirectories);
            });
    }
}