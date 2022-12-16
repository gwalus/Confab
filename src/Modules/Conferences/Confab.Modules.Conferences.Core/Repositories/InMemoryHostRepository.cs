using Confab.Modules.Conferences.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confab.Modules.Conferences.Core.Repositories
{
    internal class InMemoryHostRepository : IHostRepository
    {
        // Not thread-safe, use Concurrect collections
        private readonly List<Host> _hosts = new List<Host>();

        public Task AddAsync(Host host)
        {
            _hosts.Add(host);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyList<Host>> BrowseAsync()
        {
            await Task.CompletedTask;
            return _hosts;
        }

        public Task DeleteAsync(Host host)
        {
            _hosts.Remove(host);
            return Task.CompletedTask;
        }

        public Task<Host> GetAsync(Guid id) => Task.FromResult(_hosts.SingleOrDefault(x => x.Id == id));

        public Task UpdateAsync(Host host)
        {
            return Task.CompletedTask;
        }
    }

    internal class InMemoryConferenceRepository : IConferenceRepository
    {
        // Not thread-safe, use Concurrect collections
        private readonly List<Conference> _conferences = new();

        public Task AddAsync(Conference conference)
        {
            _conferences.Add(conference);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyList<Conference>> BrowseAsync()
        {
            await Task.CompletedTask;
            return _conferences;
        }

        public Task DeleteAsync(Conference conference)
        {
            _conferences.Remove(conference);
            return Task.CompletedTask;
        }

        public Task<Conference> GetAsync(Guid id) => Task.FromResult(_conferences.SingleOrDefault(x => x.Id == id));

        public Task UpdateAsync(Conference conference)
        {
            return Task.CompletedTask;
        }
    }
}