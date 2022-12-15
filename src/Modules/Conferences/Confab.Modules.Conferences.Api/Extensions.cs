using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Confab.Bootstrapper")]
namespace Confab.Modules.Conferences.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddConferences(this IServiceCollection services)
        {
            return services;
        }
    }
}