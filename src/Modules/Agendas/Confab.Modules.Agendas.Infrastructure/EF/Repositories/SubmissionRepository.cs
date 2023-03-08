using Confab.Modules.Agendas.Domain.Submissions.Entities;
using Confab.Modules.Agendas.Domain.Submissions.Repositories;
using Confab.Shared.Abstractions.Kernel.Types;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Confab.Modules.Agendas.Infrastructure.EF.Repositories
{
    internal sealed class SubmissionRepository : ISubmissionRepository
    {
        private readonly AgendasDbContext _dbContext;
        private readonly DbSet<Submission> _submissions;

        public SubmissionRepository(AgendasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Submission submission)
        {
            await _submissions.AddAsync(submission);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Submission> GetAsync(AggregateId id)
            => await _submissions
                .Include(x => x.Speakers)
                .SingleOrDefaultAsync(x => x.Id.Equals(id));

        public async Task UpdateAsync(Submission submission)
        {
            _dbContext.Update(submission);
            await _dbContext.SaveChangesAsync();
        }
    }
}
