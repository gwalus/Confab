using Confab.Modules.Speakers.Core.DAL;
using Confab.Modules.Speakers.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confab.Modules.Speakers.Core.DAL.Repositories
{
    internal class SpeakerRepository : ISpeakerRepository
    {
        private readonly SpeakersDbContext _dbContext;
        private readonly DbSet<Speaker> _speakers;

        public SpeakerRepository(SpeakersDbContext dbContext)
        {
            _dbContext = dbContext;
            _speakers = dbContext.Speakers;
        }

        public async Task AddAsync(Speaker speaker)
        {
            await _speakers.AddAsync(speaker);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Speaker>> BrowseAsync() 
            => await _speakers.ToListAsync();

        public async Task DeleteAsync(Speaker speaker)
        {
            _speakers.Remove(speaker);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid speakerId)
            => await _speakers.AnyAsync(speaker => speaker.Id == speakerId);

        public async Task<Speaker> GetAsync(Guid id) 
            => await _speakers.SingleOrDefaultAsync(speaker => speaker.Id == id);

        public async Task UpdateAsync(Speaker speaker)
        {
            _speakers.Update(speaker);
            await _dbContext.SaveChangesAsync();
        }
    }
}