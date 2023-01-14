using Confab.Modules.Speakers.Core.DAL;
using Confab.Modules.Speakers.Core.DAL.Repositories;
using Confab.Modules.Speakers.Core.Services;
using Confab.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Confab.Modules.Speakers.Api")]
namespace Confab.Modules.Speakers.Core
{
    internal static class Extensions
    {
        internal static IServiceCollection AddCore(this IServiceCollection services)
            => services
                .AddScoped<ISpeakerService, SpeakerService>()
                .AddScoped<ISpeakerRepository, SpeakerRepository>()
                .AddPostgres<SpeakersDbContext>();
    }
}