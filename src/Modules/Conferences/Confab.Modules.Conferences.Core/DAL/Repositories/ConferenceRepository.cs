using Confab.Modules.Conferences.Core.Entities;
using Confab.Modules.Conferences.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confab.Modules.Conferences.Core.DAL.Repositories
{
    internal class ConferenceRepository : IConferenceRepository
    {
        private readonly ConferencesDbContext _dbContext;
        private readonly DbSet<Conference> _conferences;

        public ConferenceRepository(ConferencesDbContext dbContext)
        {
            _dbContext = dbContext;
            _conferences = _dbContext.Conferences;
        }

        public async Task AddAsync(Conference conference)
        {
            await _conferences.AddAsync(conference);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Conference>> BrowseAsync() => await _conferences.ToListAsync();

        public async Task DeleteAsync(Conference conference)
        {
            _conferences.Remove(conference);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Conference> GetAsync(Guid id) => await _conferences.Include(x => x.Host).SingleOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Conference conference)
        {
            _conferences.Update(conference);
            await _dbContext.SaveChangesAsync();
        }
    }
}
